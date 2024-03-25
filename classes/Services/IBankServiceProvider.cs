using classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Services
{
    public interface IBankServiceProvider
    {
        void CreateAccount(int customer, long accountNo, string accountType, float balance);
        Account[] ListAccounts();
        float CalculateInterest(Account account);
    }
}
