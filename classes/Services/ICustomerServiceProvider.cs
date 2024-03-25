using classes.Entity;
using System;


namespace classes.Services
{
    internal interface ICustomerServiceProvider
    {
        double GetAccountBalance(long accountNo);
        double Deposit(long accountNo, float amount);
        double Withdraw(long accountNo, float amount);
        void Transfer(long fromAccountNo, long toAccountNo, float amount);
        Account GetAccountDetails(long accountNo);
    }
}
