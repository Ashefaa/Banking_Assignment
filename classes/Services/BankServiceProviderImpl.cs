using classes.Entity;
using classes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Services
{
    public abstract class BankServiceProviderImpl : CustomerServiceProviderImpl, IBankServiceProvider
    {
        private List<Account> accountList;
        private string branchName;
        private string branchAddress;

        public BankServiceProviderImpl(string branchName, string branchAddress)
        {
            accountList = new List<Account>();
            this.branchName = branchName;
            this.branchAddress = branchAddress;
        }
        public void CreateAccount(int customer, long accountNo, string accountType, float balance)
        {
            Account newAccount = new Account(accountNo, accountType, balance, customer);
            accountList.Add(newAccount);
        }
        public Account[] ListAccounts()
        {
            return accountList.ToArray();
        }
        public float CalculateInterest(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
