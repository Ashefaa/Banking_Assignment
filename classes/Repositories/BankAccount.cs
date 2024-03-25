using classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Repositories
{
    public abstract class BankAccount:Account
    {
        public BankAccount()
        {
            
        }
        public abstract void ListAll();

        public abstract void CreateAccount(Account bankAccount);

        public abstract void GetAccountBalance(long accountNo);

        public abstract void TransferAmount(int sender, int receiver, float amount);

        public abstract void GetAccountDetails(long accountNo);

        public abstract void Deposit(long accountNo, float amount);
        public abstract void Withdraw(long accountNo, float amount);
        public abstract void CalculateInterest(long accountNo);
    }
}
