using System;
using System.Transactions;
using System.Xml.Serialization;
using classes.Entity;
using classes.Exceptions;
using classes.Services;

namespace BankManagement.Services
{
    public class CustomerServiceProviderImpl : ICustomerServiceProvider
    {
        private Dictionary<long, Account> accounts = new Dictionary<long, Account>();
        private Dictionary<long, Customer> customers = new Dictionary<long, Customer>();

        public float GetAccountBalance(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return (float)accounts[accountNumber].Balance;
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

        public float Deposit(long accountNumber,float amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                switch (account.AccountType)
                {
                    case "Savings":
                        account.Balance += amount;
                        return (float)account.Balance;
                    case "Current":
                        account.Balance += amount;
                        return (float)account.Balance;
                    default:
                        throw new InvalidOperationException("Invalid account type.");
                }
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

        public float Withdraw(long accountNumber, float amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                switch (account.AccountType)
                {
                    case "Savings":
                        if (account.Balance - amount < 500)
                        {
                            throw new InvalidOperationException("Withdrawal violates minimum balance rule.");
                        }
                        account.Balance -= amount;
                        return (float)account.Balance;
                    case "Current":
                        if (amount > account.Balance + ((CurrentAccount)account).OverDraftLimit)
                        {
                            throw new InvalidOperationException("Withdrawal exceeds available balance and overdraft limit.");
                        }
                        account.Balance -= amount;
                        return (float)account.Balance;
                    default:
                        throw new InvalidOperationException("Invalid account type.");
                }
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

        public bool Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            if (accounts.ContainsKey(fromAccountNumber) && accounts.ContainsKey(toAccountNumber))
            {
                Account fromAccount = accounts[fromAccountNumber];
                Account toAccount = accounts[toAccountNumber];
                if (fromAccount.Balance < amount)
                {
                    throw new InvalidOperationException("Insufficient funds for transfer.");
                }
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
                return true;
            }
            else
            {
                throw new ArgumentException("One or both accounts not found.");
            }
        }

        public (Account, Customer) GetAccountDetails(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                Customer customer = customers.ContainsKey(account.AccountHolder) ? customers[account.AccountHolder] : null;
                return (account, customer);
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

        double ICustomerServiceProvider.GetAccountBalance(long accountNo)
        {
            throw new NotImplementedException();
        }

        double ICustomerServiceProvider.Deposit(long accountNo, float amount)
        {
            throw new NotImplementedException();
        }

        double ICustomerServiceProvider.Withdraw(long accountNo, float amount)
        {
            throw new NotImplementedException();
        }

        void ICustomerServiceProvider.Transfer(long fromAccountNo, long toAccountNo, float amount)
        {
            throw new NotImplementedException();
        }

        Account ICustomerServiceProvider.GetAccountDetails(long accountNo)
        {
            throw new NotImplementedException();
        }
    }
    
}
;