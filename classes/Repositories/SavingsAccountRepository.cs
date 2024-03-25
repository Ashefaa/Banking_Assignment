using System;


namespace classes.Repositories
{
    public  class SavingsAccountRepository:BankAccountRepository
    {
        public double interestRate;
        public SavingsAccountRepository(int accountNumber,string customerName,double balance,double interestRate):base(accountNumber,customerName,balance)
        {
            interestRate = interestRate;
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Amount Deposited {amount},current balance {Balance} ");
        }
        public override void Withdraw(double amount)
        {
           if(amount <= Balance)
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
            double interest = Balance * interestRate / 100;
            Balance += interest;
            Console.WriteLine($"Interest calculated is {Balance}");
        }

    }
}
