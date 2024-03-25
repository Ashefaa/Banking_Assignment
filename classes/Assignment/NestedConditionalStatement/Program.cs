namespace NestedConditionalStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Current Account Balance");
            double accountbalance = Convert.ToDouble(Console.ReadLine());
            Mainmenu:
            Console.WriteLine("Enter Your Amount to withdraw or deposit");
            double amount = Convert.ToDouble(Console.ReadLine());
            //double depositbalance;
            while (true)
            {
                
                Console.WriteLine("ATM Functionalities");
                Console.WriteLine("1.Check Balance");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Please Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine($"Your Current Balance is {accountbalance}");
                        break;
                    case 2:
                        accountbalance  += amount;
                        Console.WriteLine($"Deposit Successful!!The balance after depositing is {accountbalance}");
                        break;
                    case 3:
                        if (amount > accountbalance)
                        {
                            Console.WriteLine("Sorry!Insufficient Balance.PleaseEnter a Valid Balance");
                            goto Mainmenu;
                        }
                        else if(amount%100 !=0 && amount%500 !=0)
                        {
                            Console.WriteLine("Withdrawal amount must be in multiples og 100 or 500");
                            goto Mainmenu;
                        }
                        else
                        {
                            accountbalance -= amount;
                            Console.WriteLine($"Withdrawal successfull!The remaining balance is {accountbalance}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank You!!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid Choice");
                        break;



                }
            }
        }
    }
}
