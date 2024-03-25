using classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankManagement.Repository
{
    public abstract class IBankRepository:Account
    {
       
        public abstract void GetAccountBalance(long accountNumber);

        public abstract void TransferAmount(int sender, int receiver, float amount);

        public abstract void GetAccountDetails(long accountNumber);

        public abstract void Deposit(long accountNumber, float amount);

   
        public abstract void Withdraw(long accountNumber, float amount);
        public abstract List<Account> ListAccounts();

        public abstract void CreateAccount(Account account);

        public abstract void CalculateInterest(string id);

    }
}
