using BankManagement.Exceptions;
using BankManagement.Repositories;
using BankManagement.Utilities;
using classes.Exceptions;
using classes.Repositories;
using System.Data.SqlClient;


namespace classes.Entity
{
    public class CurrentAccount:BankAccount
    {
        //internal float OverdraftLimit;

        //public double overdraftLimit = -500;
        #region task 8 question 2
        //public override void Withdraw(double amount)
        //{
        //    if(balance-amount < overdraftLimit)
        //    {
        //        Console.WriteLine("Overdraft Limit exceeded");
        //    }
        //    else
        //    {
        //        {
        //            balance -= amount;
        //            Console.WriteLine($"{amount} withdrawn successful.");
        //        }
        //    }
        //}
        #endregion
        #region task 9 question 2
        //public CurrentAccount(double initialBlance):base(initialBlance)
        //{

        //}
        //public override void Withdraw(double amount)
        //{
        //    if (balance - amount < overdraftLimit)
        //    {
        //        Console.WriteLine("Overdraft Limit exceeded");
        //    }
        //    else
        //    {
        //        {
        //            balance -= amount;
        //            Console.WriteLine($"{amount} withdrawn successful.");
        //        }
        //    }
        //}
        #endregion
        #region task 11 question 3

        //public double OverdraftLimit
        //{ get; }
        //public CurrentAccount(Customer customer, double overdraftLimit):base("Current",0,customer)
        //{
        //    OverdraftLimit = overdraftLimit;
        //}
        //public void Withdraw(double amount,double balance)
        //{
        //    if(balance + OverdraftLimit>amount)
        //    {
        //        balance -= amount;
        //        Console.WriteLine($"Withdrawn {amount}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Insufficient Balance");
        //    }
        //}
        #endregion
        //public float OverDraftLimit { get; set; }

        //public CurrentAccount(Customer accountOwner,float overDraftLimit):base("Current",0,accountOwner)
        //{
        //    OverDraftLimit = overDraftLimit;
        //}
        public double InterestRate { get; set; } = 4.5;
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public CurrentAccount()
        {
            sql = new SqlConnection(DBUtil.GetConnection());
            cmd = new SqlCommand();
        }

        public double OverDraftLimit { get; set; } = 10000;

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
        public override void Deposit(long id, float amount)
        {
            Account currentAccount = bankAccounts.Find(x => x.AccountNumber == id);
            currentAccount.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {currentAccount.Balance}");
        }

        public override void CalculateInterest(long id)
        {
            Console.WriteLine("Current account has no interest");
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

                if (amount > availableBalance + OverDraftLimit)
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                sql.Close();
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

        public override void TransferAmount(int sender, int receiver, float amount)
        {
            throw new NotImplementedException();
        }

    }
}
