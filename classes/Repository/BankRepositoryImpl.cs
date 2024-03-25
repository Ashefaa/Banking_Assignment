using BankManagement.Exceptions;
using BankManagement.Utilities;
using classes.Entity;
using classes.Exceptions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Repository
{
    public class BankRepositoryImpl:IBankRepository
    {
        SqlConnection sql = null;
        SqlCommand cmd = null;
        SavingsAccount savingsAccount = new SavingsAccount();
        CurrentAccount currentAccount = new CurrentAccount();
        ZeroBalanceAccount zeroBalanceAccount = new ZeroBalanceAccount();
        public BankRepositoryImpl()
        {
            sql = new SqlConnection(DBUtil.GetConnection());
            cmd = new SqlCommand();
        }
        public  override void GetAccountDetails(long accountNo)
        {
            try
            {
                cmd.CommandText = "Select * from Accounts where account_id=@Id";
                cmd.Connection = sql;
                cmd.Parameters.AddWithValue("@Id", accountNo);
                sql.Open();
                cmd.Connection = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        Account account = new Account();
                        account.AccountNumber = (long)reader["account_id"];
                        account.CustomerId = (int)reader["customer_id"];
                        account.AccountType = (string)reader["account_type"];
                        account.Balance = (double)((decimal)reader["balance"]);

                   
                }
                Console.WriteLine($"Account Id:{AccountNumber}\t Customer Id:{CustomerId}\tAccount Type :{AccountType}\t Balance:{Balance}");

            }
            catch(SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            sql.Close();
        }
        public override void Deposit(long accountNo,float amount)
        {
            try
            {
                cmd.CommandText = "update Accounts set balance=balance+@amount where account_id=@Id";
                cmd.Connection = sql;

                sql.Open();
                cmd.Parameters.AddWithValue("@Id", accountNo);
                cmd.Parameters.AddWithValue("@amount", amount);
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                { 
                    Console.WriteLine($"Thank you for using {accountNo}"); 

                }
                else
                {
                    throw new ServerIssueException("There seems to be issue with the server");
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            sql.Close();
        }

        public override void Withdraw(long accountNumber,float amount)
        {
            try
            {
                cmd.CommandText = "select account_id from Accounts where account_id=@Id ";
                cmd.Connection = sql;
                sql.Open();
                string type = "";
                cmd.Parameters.AddWithValue("@Id", accountNumber);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    type = (string)reader["account_type"];

                }
                if(type=="Savings")
                {
                    savingsAccount.Withdraw(accountNumber, amount);

                }
                else if(type == "Current")
                {
                    currentAccount.Withdraw(accountNumber,amount);
                }
                else
                {
                    zeroBalanceAccount.Withdraw(accountNumber, amount);
                }
            }
            catch(SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            finally
            {
                sql.Close();
            }
        }
        public override void TransferAmount(int sender, int receiver, float amount)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Accounts WHERE account_id = @sender OR account_id = @receiver";
                cmd.Connection = sql;
                cmd.Parameters.AddWithValue("@sender", sender);
                cmd.Parameters.AddWithValue("@receiver", receiver);

                sql.Open();

                Dictionary<int, double> accountBalances = new Dictionary<int, double>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int accountId = (int)reader["account_id"];
                        double balance = (double)((decimal)reader["balance"]); ;
                        accountBalances.Add(accountId, balance);
                    }
                }

                if (!accountBalances.ContainsKey(sender))
                {
                    throw new Exception("The sender account does not exist.");
                }

                if (!accountBalances.ContainsKey(receiver))
                {
                    throw new Exception("The receiver account does not exist.");
                }

                if (accountBalances[sender] < amount)
                {
                    throw new Exception("The sender does not have sufficient balance to transfer.");
                }

                cmd.CommandText = "UPDATE Accounts SET balance = @senderBalance WHERE account_id = @sender;" +
                                  "UPDATE Accounts SET balance = @receiverBalance WHERE account_id = @receiver;";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@sender", sender);
                cmd.Parameters.AddWithValue("@receiver", receiver);
                cmd.Parameters.AddWithValue("@senderBalance", accountBalances[sender] - amount);
                cmd.Parameters.AddWithValue("@receiverBalance", accountBalances[receiver] + amount);
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine($"Transfer of {amount} from account {sender} to account {receiver} successful.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
                sql.Close();
            
        }


        public override void GetAccountBalance(long accountNumber)
        {
            try
            {
                cmd.CommandText = "Select balance from Accounts where account_id = @id";
                cmd.Connection = sql;

                sql.Open();
                cmd.Parameters.AddWithValue("@id", accountNumber);


                double Balance = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Balance = (float)(reader["balance"]);
                    }
                }

                Console.WriteLine($"Your Account Balance is : {Balance}");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }

            finally
            {
                sql.Close();
            }
        }
        public override void CalculateInterest(string id)
        {

            try
            {
                int dId = 0;
                InvalidAccountException.CheckIfInteger(id, ref dId);




                try
                {
                    cmd.CommandText = "select account_type from Accounts where account_id = @id";
                    cmd.Connection = sql;
                    sql.Open();
                    string type = "";
                    cmd.Parameters.AddWithValue("@id", dId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        type = (string)reader["account_type"];
                    }

                    if (type == "Savings")
                    {
                        savingsAccount.CalculateInterest(dId);
                    }
                    else if (type == "Current")
                    {
                        currentAccount.CalculateInterest(dId);

                    }
                    else
                    {
                        zeroBalanceAccount.CalculateInterest(dId);
                    }
                }
                catch (SqlException sqlexp)
                {
                    Console.WriteLine(sqlexp.Message);
                }
                
                    sql.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public override List<Account> ListAccounts()
        {
            List<Account> account = new List<Account>();

            cmd.CommandText = "Select * from Accounts";
            cmd.Connection = sql;

            sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Account account1 = new Account();

                account1.AccountNumber = (int)reader["account_id"];
                account1.AccountHolder = (int)reader["customer_id"];
                account1.AccountType = (string)reader["account_type"];
                account1.Balance = (float)reader["balance"];
                //Console.WriteLine(a.AccountId);
                account.Add(account1);

            }
            sql.Close();


            return account;
        }

        public override void CreateAccount(Account bankAccount)
        {
            cmd.CommandText = "insert into Accounts(customer_id,account_type,balance) values(@customerId,@accounttype,@balance)";
            cmd.Connection = sql;
            sql.Open();
            
            cmd.Parameters.AddWithValue("@customerId", bankAccount.AccountHolder);
            cmd.Parameters.AddWithValue("@accounttype", bankAccount.AccountType);
            cmd.Parameters.AddWithValue("@balance", bankAccount.Balance);
            int rows = cmd.ExecuteNonQuery();
            cmd.CommandText = "Select account_id from Accounts where customer_id = @id and account_type = @type and balance = @b";
            cmd.Parameters.AddWithValue("@id", bankAccount.AccountHolder);
            cmd.Parameters.AddWithValue("@type", bankAccount.AccountType);
            cmd.Parameters.AddWithValue("@b", bankAccount.Balance);
            SqlDataReader reader = cmd.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = (int)reader["account_id"];
            }
           
            Console.WriteLine($"Your Account has been created naming {bankAccount.AccountHolder} and the AccountId is {id}");
        }

    }
}


       
