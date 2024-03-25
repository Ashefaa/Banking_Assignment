using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Exceptions
{
    internal class ServerIssueException:Exception
    {
        public ServerIssueException(string message) : base(message) { }
    }
}
