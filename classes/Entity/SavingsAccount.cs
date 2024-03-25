using BankManagement.Exceptions;
using BankManagement.Repositories;
using BankManagement.Utilities;
using classes.Exceptions;
using classes.Repositories;
using System;
using System.Data.SqlClient;


namespace classes.Entity
{
    public class SavingsAccount:BankAccount
    {
        // public double interestRate=0.04;
        //public double balance;

        #region task 8 question 2
        //public SavingsAccount(double interestRate)
        //{
        //    this.interestRate = interestRate;
        //}
        //public override double CalculateInterest()
        //{
        //    return balance * interestRate;
        //}
        #endregion
        #region task 9 question 2
        //public SavingsAccount(double initialBalance,double interestRate):base(initialBalance)
        //{
        //    this.interestRate = interestRate;
        //}

        //public SavingsAccount()
        //{
        //}

        //////method to withdraw amount
        //public  void Withdraw(double amount)
        //{
        //   if(balance >= amount)
        //    {
        //        balance -= amount;
        //        Console.WriteLine($"{amount} withdrawn successfully");
        //   }
        //    else
        //    {
        //        Console.WriteLine("Insufficient Balance");
        //    }
        //}
        //public  void CalculateInterest()
        //{
        //    double interest = balance * interestRate;
        //    balance += interest; 
        //    Console.WriteLine($"Interest calculated and added {interest}");
        //}
        #endregion
        #region task 11 question 3
        //public double interestRate
        //{ get; }
        //public SavingsAccount(Customer customer,double interestRate):base("Savings",500,customer)
        //{
        //    interestRate = interestRate;
        //}
        #endregion
        //public float InterestRate { get; set; }

        //public SavingsAccount(long accNo, Customer accountHolder,float interestRate):base ("Savings",500,accountHolder)
        //{
        //    InterestRate = interestRate;
        //}

        //public SavingsAccount()
        //{
        //}

        public double InterestRate { get; set; } = 4.5;
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public SavingsAccount()
        {
            sql = new SqlConnection(DBUtil.GetConnection());
            cmd = new SqlCommand();
        }

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

        public override void Deposit(long id,float amount)
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

        public override void Withdraw(long id,float amount)
        {
            try
            {
                cmd.CommandText = "SELECT balance FROM Accounts WHERE account_id = @id";
                cmd.Connection = sql;
                double availableBalance = 0;

                sql.Open();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    availableBalance = (double)reader["balance"];
                }
                reader.Close(); // Close the SqlDataReader

                if (amount > availableBalance)
                {
                    throw new InsufficientFundException("You don't have enough balance");
                }
                else
                {
                    // Update the balance by subtracting the withdrawal amount
                    cmd.CommandText = "UPDATE Accounts SET balance = balance - @amount WHERE account_id = @id";
                    cmd.Parameters.Clear(); // Clear previous parameters

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
