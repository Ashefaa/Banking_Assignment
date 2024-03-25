using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Exceptions
{
    public class OverDraftLimitExceededException:Exception
    {
        public OverDraftLimitExceededException()
        { }
        public OverDraftLimitExceededException(string message) : base(message)
        {

        }
    }
}
