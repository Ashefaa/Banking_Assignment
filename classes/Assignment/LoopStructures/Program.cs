namespace LoopStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of customers:");
            int numberofcustomer = int.Parse(Console.ReadLine());
            for(int i=1;i<=numberofcustomer;i++)
            {
                Console.WriteLine($"Customer {i}:");
                Console.WriteLine("Please enter the initial balance:");
                double initialbalance = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter your annual interest rate:");
                int annualinterestrate = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter the Number of Years");
                int numberofyears = int.Parse(Console.ReadLine());
                double futurebalance;
                futurebalance = initialbalance * Math.Pow (1 + annualinterestrate / 100, numberofyears);
                Console.WriteLine($"Future balance after {numberofyears} is {futurebalance}");
            }
        }
    }
}
