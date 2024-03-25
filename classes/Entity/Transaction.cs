using classes.Entity;
using System;


namespace BankManagement.Entity
{
    public class Transaction
    {
        public Account Account { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public TransactionType Type { get; set; }
        public float TransactionAmount { get; set; }

        public Transaction(Account account,string description,DateTime dateTime,TransactionType type,float amount)
        {
            Account = account;
            Description = description;
            DateTime = dateTime;
            Type = type;
            TransactionAmount = amount;
        }
    }
    public enum TransactionType
    {
        Withdraw,
        Deposit,
        Transfer
    }
}
