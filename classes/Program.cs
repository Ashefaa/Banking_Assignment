using BankManagement.Services;
using classes.Entity;
using classes.Repositories;

namespace classes
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Classes and Object 
            //Customer customer1 = new Customer();
            //Customer customer2 = new Customer("1", "Ashefa", "JafferAli", "ashefa.j@gmail.com", "6678543219", "Coonoor");
            //Console.WriteLine("Customer Information:");
            ////customer1.PrintCustomerInfo();
            ////customer2.PrintCustomerInfo();
            //Account account1 = new Account("123456","savings",10000.00);
            //Console.WriteLine("Account Information:");
            //account1.printAccountInfo();
            //account1.Deposit(5000.00);
            //account1.Withdraw(2000.00);
            //account1.calculateInterest();
            #endregion
            #region task 8 question 1
            //AccountRepository accountrepo = new AccountRepository();
            ////depositing and withdrawing using float values
            //accountrepo.Deposit(1000.5f);
            //accountrepo.Withdraw(500.75f);
            ////depositing and withdrawing using int values
            //accountrepo.Deposit(1000);
            //accountrepo.Withdraw(750);
            ////depositing and withdrawing using double values
            //accountrepo.Deposit(1000.50);
            //accountrepo.Withdraw(700.00);

            //Console.WriteLine($"Current Balance {accountrepo.getBalance()}");

            #endregion
            #region task 8 question 2
            //SavingsAccount savingsAccount = new SavingsAccount(0.02);
            //savingsAccount.Deposit(1000);
            //Console.WriteLine($"Interest Earned {savingsAccount.CalculateInterest()}");

            //CurrentAccount currentAccount = new CurrentAccount();
            //currentAccount.Deposit(1000);
            //currentAccount.Withdraw(800);
            //currentAccount.Withdraw(70000);
            #endregion
            #region task 8 question 3
            //AccountRepository accountrepo = null;
            //double initialBalance = 0;

            //Console.WriteLine("Choose account type:");
            //Console.WriteLine("1. Savings Account");
            //Console.WriteLine("2. Current Account");
            //int choice = int.Parse(Console.ReadLine());

            //switch (choice)
            //{
            //    case 1:
            //        Console.WriteLine("Enter initial balance for Savings Account:");
            //        initialBalance = double.Parse(Console.ReadLine());
            //        Console.WriteLine("Enter interest rate for Savings Account:");
            //        double interestRate = double.Parse(Console.ReadLine());
            //        accountrepo = new SavingsAccount(initialBalance, interestRate);
            //        break;
            //    case 2:
            //        Console.WriteLine("Enter initial balance for Current Account:");
            //        initialBalance = double.Parse(Console.ReadLine());
            //        accountrepo = new CurrentAccount(initialBalance);
            //        break;
            //    default:
            //        Console.WriteLine("Invalid choice.");
            //        break;
            //}

            //if (accountrepo != null)
            //{
            //    Console.WriteLine("Choose operation:");
            //    Console.WriteLine("1. Deposit");
            //    Console.WriteLine("2. Withdraw");
            //    Console.WriteLine("3. Calculate Interest (for Savings Account)");

            //    int operation = int.Parse(Console.ReadLine());

            //    switch (operation)
            //    {
            //        case 1:
            //            Console.WriteLine("Enter deposit amount:");
            //            double depositAmount = double.Parse(Console.ReadLine());
            //            accountrepo.Deposit(depositAmount);
            //            break;
            //        case 2:
            //            Console.WriteLine("Enter withdraw amount:");
            //            double withdrawAmount = double.Parse(Console.ReadLine());
            //            accountrepo.Withdraw(withdrawAmount);
            //            break;
            //        case 3:
            //            if (accountrepo is SavingsAccount)
            //            {
            //                ((SavingsAccount)accountrepo).CalculateInterest();
            //            }
            //            else
            //            {
            //                Console.WriteLine("Calculate Interest is not applicable for Current Account.");
            //            }
            //            break;
            //        default:
            //            Console.WriteLine("Invalid operation.");
            //            break;
            //    }

            //    Console.WriteLine("Current balance: " + accountrepo.GetBalance());
            //}
            #endregion
            #region   task 9 question 1
            //SavingsAccountRepository savingsAccountRepository = new SavingsAccountRepository(12345, "Ashefa", 1000,0.04);
            //CurrentAccountRepository currentAccountRepository = new CurrentAccountRepository(45678, "Indira", 500,500);

            //savingsAccountRepository.Deposit(500);
            //savingsAccountRepository.Withdraw(1000);

            //currentAccountRepository.Deposit(500);
            //currentAccountRepository.Withdraw(100);

            //Console.WriteLine("Savings Account:");
            //Console.WriteLine(savingsAccountRepository);

            //Console.WriteLine("\tCurrent Account:");
            //Console.WriteLine(currentAccountRepository);
            #endregion
            #region task 10 question 1
            //Customer customer = new Customer(1,"Ashefa","JafferAli","ashefa.j@email.com","9087654321","Coonoor");
            //Console.WriteLine("Print Customer 1 Information:");
            //customer.printCustomer();

            //Customer customer2 = new Customer();
            //customer2.CustomerId = 2;
            //customer2.FirstName = "Indira";
            //customer2.LastName = "Priya";
            //customer2.EmailId = "indira.com";
            //customer2.PhoneNo = "12345678";
            //customer2.Address = "Coimbatore";
            //Console.WriteLine("Print Customer 2 Information:");
            //customer2.printCustomer();
            #endregion
            #region task 10 question 2
            // Customer customer = new Customer(1, "Ashefa", "JafferAli", "ashefa.j@email.com", "9087654321", "Coonoor");
            // Account account = new Account(1001,"Savings",1500.75,customer);

            // Console.WriteLine("Account Information");
            //account.PrintAccount();
            #endregion
            #region task 11 question 2
            //Customer customer1 = new Customer("Ashefa", "Coonoor");
            //Account account1 = new Account("Savings", 1000.00, customer1);
            //Console.WriteLine(account1);
            #endregion
            #region task 11 question 3
            //Customer customer = new Customer("Ashefa","Coimbatore");

            //SavingsAccount savingsAccount = new SavingsAccount(customer, 0.05);
            //CurrentAccount currentAccount = new CurrentAccount(customer, 1000);
            //ZeroBalanceAccount zeroBalanceAccount = new ZeroBalanceAccount(customer);

            //Console.WriteLine(savingsAccount);
            //Console.WriteLine(currentAccount);
            //Console.WriteLine(zeroBalanceAccount);
            #endregion
            #region task 11 question 8
            //BankApp bankApp = new BankApp();
            //bankApp.Run();
            #endregion

            BankApp bankApp = new BankApp();
            bankApp.Bank();
        }
    }
}
