using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Entity
{
    public class Account
    {

        public static List<Account> bankAccounts = new List<Account>();
        public Account()
        { }
        #region task 7 question 2
        //string accountNumber;
        //string accountType;
        //double accountBalance;
        ////default constructor
        //public Account()
        //{}
        ////parameterized constructor
        //public Account(string accountNumber,string accountType,double accountBalance)
        //{
        //    this.accountNumber = accountNumber;
        //    this.accountType = accountType;
        //    this.accountBalance = accountBalance;
        //}
        ////getter and setter
        //public string AccountNumber
        //{
        //    get { return accountNumber; }
        //    set { accountNumber = value; }
        //}
        //public string AccountType
        //{
        //    get { return accountType; }
        //    set { accountType = value; }
        //}
        //public double AccountBalance
        //{
        //    get { return accountBalance; }
        //    set { accountBalance = value; }
        //}
        ////print the account balance
        //public void printAccountInfo()
        //{
        //    Console.WriteLine($"Account Number: {accountNumber}");
        //    Console.WriteLine($"Account Type: {accountType}");
        //    Console.WriteLine($"Account Balance: {accountBalance}");
        //}
        ////Method to deposit amount
        //public void Deposit(double amount)
        //{
        //    accountBalance += amount;
        //    Console.WriteLine($"Deposited Amount is: {amount} and New Balance: {accountBalance}");
        //}
        ////method for withdraw 
        //public void Withdraw(double amount)
        //{
        //    if(accountBalance >= amount)
        //    {
        //        accountBalance -= amount;
        //        Console.WriteLine($"Withdrawn amount:{amount} and New Balance: {accountBalance}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Insufficient Balance");
        //    }
        //}
        ////method for calculating interest
        //public void calculateInterest()
        //{
        //    double rate = 4.5 / 100;
        //    double interestbalance = rate * accountBalance;
        //    accountBalance += interestbalance;
        //    Console.WriteLine($"Interest Balance calculated : {interestbalance} New Account Balance: {accountBalance} ");
        //}

        #endregion
        #region task 9 question 2
        //public int accountNo;
        //public string accountType;
        //public double accountBalance;
        //public Customer accountOwner;

        //public int AccountNo
        //{
        //    get { return accountNo; }
        //    set { accountNo = value; }
        //}
        //public string AccountType
        //{
        //    get { return accountType; }
        //    set { accountType = value; }
        //}
        //public double AccountBalance
        //{
        //    get { return accountBalance; }
        //    set { accountBalance = value; }
        //}
        //public Customer AccountOwner
        //{
        //    get { return accountOwner; }
        //    set { accountOwner = value; }
        //}
        //public Account()
        //{

        //}
        //public Account(int accountNo,string accountType,double accountBalance,Customer accountOwner)
        //{
        //    AccountNo = accountNo;
        //    AccountType = accountType;
        //    AccountBalance = accountBalance;
        //    AccountOwner = accountOwner;
        //}
        //public void PrintAccount()
        //{
        //    Console.WriteLine($"Account Number {accountNo}");
        //    Console.WriteLine($"Account Type {accountType}");
        //    Console.WriteLine($"Account Balance {accountBalance}");
        //    Console.WriteLine($"Account Holder ");
        //    AccountOwner.printCustomer();
        //}
        #endregion
        
        //initial account number
        private static long lastaccountNo=1000;
        public long AccountNumber
        { get; set; }

        public long CustomerId { get; set; }
        public string AccountType
        { get; set; }
        public double Balance
        { get; set; }
        
        public int AccountHolder
        { get; set; }
        public double InitialBalance { get; }

        public Account(long accountNo, string accountType,double balance,int accountHolder)
        {
           
            AccountNumber = GenerateAccountNumber();
            CustomerId = CustomerId;
            this.AccountType = accountType;
            this.Balance = balance;
            this.AccountHolder = accountHolder;
        }

        public Account(double initialBalance)
        {
            InitialBalance = initialBalance;
        }

        public override string ToString()
        {
          return $"Account Number: {AccountNumber}\tAccount Type:{AccountType}\tBalance:{Balance}\tCustomer:{AccountHolder}";
        }
        //Method to generate account number
        public static long GenerateAccountNumber()
        {
            return ++lastaccountNo;
        }
        
    }
}
