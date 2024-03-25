using System;

namespace classes.Repositories
{
    public abstract class BankAccountRepository
    {
        public int accountNo;
        public string accountName;
        public double balance;

        public int AccountNo
        {
            get { return accountNo; }
            set { accountNo = value; }
        }
        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public BankAccountRepository()
        {

        }
        public BankAccountRepository(int accountNo, string accountName,double balance)
        {
            AccountNo = accountNo;
            AccountName = accountName;
            Balance = balance;
        }
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void CalculateInterest();

        public override string ToString()
        {
            return $"Account No: {AccountNo}\t Account Name: {AccountName}\t  Balance: {Balance}";
        }
    }
}
