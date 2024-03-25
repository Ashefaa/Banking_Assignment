using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Looping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] accountnumber = { "12345", "56789", "90876", "76543" };
            double[] accountbalance = { 10000.00, 25000.00, 43000.00, 13300.00 };

            while (true)
            {
                Console.WriteLine("Please Enter your account number:");
                string enteredaccountno = Console.ReadLine();
                int index = Checking(enteredaccountno, accountnumber);
                if (index < 0)
                {
                    Console.WriteLine("Sorry!No user Found.Please Enter a Valid account number");
                }
                else
                {
                    Console.WriteLine($"The balance of the account number {accountnumber[index]} is {accountbalance[index]}");
                }
            }
        }
               
            public static int Checking(string enteredaccountno,string[] accountnumber)
            {
                for (int i = 0; i < accountnumber.Length; i++)
                {
                    if (accountnumber[i].Equals(enteredaccountno))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }
    
}
