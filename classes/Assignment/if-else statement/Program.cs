using System.Collections.Concurrent;

namespace if_else_statement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your credit score:");
            int creditscore = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your annual income:");
            int annualIncome = int.Parse(Console.ReadLine());
            if(creditscore > 700 && annualIncome >50000)
            {
                Console.WriteLine("Eligible for Loan!");
            }
            else
            {
                Console.WriteLine("Sorry!Not Eligible for Loan");
            }
        }
    }
}
