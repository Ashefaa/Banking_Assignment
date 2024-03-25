using BankManagement.Exceptions;
using BankManagement.Repositories;
using BankManagement.Utilities;
using classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Entity
{
    public class ZeroBalanceAccount:BankAccount
    {
        //public ZeroBalanceAccount()
        //{
        //}

        //public ZeroBalanceAccount(Customer accountOwner) : base("Zero Balance", 0, accountOwner)
        //{ }

        SqlConnection sql = null;
        SqlCommand cmd = null;

        public ZeroBalanceAccount()
        {
            sql = new SqlConnection(DBUtil.GetConnection());
            cmd = new SqlCommand();
        }
        public double InterestRate { get; set; } = 4.5;

        public override void CreateAccount(Account bankAccount)
        {
            bankAccounts.Add(bankAccount);
            Console.WriteLine($"Your Account has been created naming {bankAccount.AccountHolder} and the AccountId is  {bankAccount.AccountNumber}");

        }
        public override void ListAll()
        {
            foreach (Account acc in bankAccounts)
            {
                Console.WriteLine(acc);
            }
        }
        public override void GetAccountDetails(long id)
        {
            Account currentAccount = bankAccounts.Find(x => x.AccountNumber == id);
            Console.WriteLine(currentAccount);
        }

        public override void GetAccountBalance(long id)
        {
            Account currentAccount = bankAccounts.Find(x => x.AccountNumber == id);
            Console.WriteLine($"The bank balance for the account {currentAccount.AccountNumber} is {currentAccount.Balance}");
        }

        public override void Deposit(long id, float amount)
        {
            Account savingsObject = bankAccounts.Find(x => x.AccountNumber == id);


            savingsObject.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {savingsObject.Balance}");
        }

        public override void CalculateInterest(long id)
        {
            cmd.CommandText = "select balance from Accounts where account_id = @accId";
            cmd.Connection = sql;
            sql.Open();

            cmd.Parameters.AddWithValue("@accId", id);

            SqlDataReader r = cmd.ExecuteReader();
            double Balance = 0;

            while (r.Read())
            {
                Balance = (double)((decimal)r["balance"]);
            }

            
            double InterestRate = 4.5;
            double interest = Balance * (InterestRate / 100);
            Console.WriteLine($"Interest calculated: {interest}. New balance: {Balance}");
        }

        public override void Withdraw(long id, float amount)
        {
            try
            {
                cmd.CommandText = "SELECT balance FROM Accounts WHERE account_id = @id";
                cmd.Connection = sql;
                double availableBalance = 0;

                sql.Open();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    availableBalance = (double)((decimal)r["balance"]);
                }
                r.Close(); // Close the SqlDataReader

                if (amount > availableBalance)
                {
                    throw new InsufficientFundException("You don't have enough balance");
                }
                else
                {
                    // Update the balance by subtracting the withdrawal amount
                    cmd.CommandText = "UPDATE Accounts SET balance = balance - @amount WHERE account_id = @id";
                    cmd.Parameters.Clear(); 

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Console.WriteLine($"Withdrawal successful from account {id}");
                    }
                    else
                    {
                        throw new ServerIssueException("Failed to update balance. There seems to be an issue with the server.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
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


                Account senderAccount = bankAccounts.Find(x => x.AccountNumber == sender);
                Account recieverAccount = bankAccounts.Find(x => x.AccountNumber == receiver);

                if (senderAccount == null)
                {
                    throw new Exception("The sender Id does not exist");
                }

                else if (recieverAccount == null)
                {
                    throw new Exception("The Account you are trying to send doesnot exist");
                }
                else
                {
                    senderAccount.Balance -= amount;
                    recieverAccount.Balance += amount;
                    Console.WriteLine($"The new balance of sender is {senderAccount.Balance} and reciever Account is {recieverAccount.Balance}");
                }


            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
