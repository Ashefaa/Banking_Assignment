using System;


namespace classes.Repositories
{
    internal class CurrentAccountRepository:BankAccountRepository
    {
        public double overdraftlimit;
        public CurrentAccountRepository(int accountNumber, string customerName, double balance, double overdraftLimit) : base(accountNumber, customerName, balance)
        {
            overdraftLimit=overdraftLimit;
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Amount Deposited {amount},current balance {Balance} ");
        }
        public override void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Amount withdrawn {amount},current balance {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        public override void CalculateInterest()
        {
         
            Console.WriteLine("Interest cannot be calculated");
        }
    }
}
