using classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Exceptions
{
    public class InvalidAccountException:Exception
    {
        
        public InvalidAccountException(string message) : base(message)
        {

        }
        public static void CheckIfInteger(string message, ref int dId)
        {
            if (!int.TryParse(message, out int value1))
            {
                throw new InvalidAccountException("Please Provide a proper Account Number..");
            }
            dId = value1;
        }
    }
}
