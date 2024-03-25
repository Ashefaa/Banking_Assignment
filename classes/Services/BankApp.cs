using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagement.Repository;
using classes.Entity;
using classes.Exceptions;

namespace BankManagement.Services
{
    public class BankApp
    {

        public void Bank()
        {
            //int randomNumber = 1000;
            SavingsAccount savingsAccount = new SavingsAccount();
            ZeroBalanceAccount zeroBalanceAccount = new ZeroBalanceAccount();
            CurrentAccount currentAccount = new CurrentAccount();

            BankRepositoryImpl bankRepository = new BankRepositoryImpl();

        Mainmenu: while (true)
            {

                Console.WriteLine("\nWelcome to Banking System Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Calculate Interest");
                Console.WriteLine("Enter your Choice");

                int choice = int.Parse(Console.ReadLine());
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Select the type of Account ");
                            Console.WriteLine("1. Savings Account");
                            Console.WriteLine("2. Current Account");
                            Console.WriteLine("3. Zero Balance Account");
                            Console.WriteLine("4. Goto Main Menu");
                            int ch = Convert.ToInt32(Console.ReadLine());
                            switch (ch)
                            {
                                case 1:

                                    try
                                    {
                                        Account accounts = new Account();
                                        Console.WriteLine("Enter you customer Id:");
                                        string stringId = Console.ReadLine();
                                        int accountName = 0;
                                        InvalidAccountException.CheckIfInteger(stringId, ref accountName);

                                        Console.WriteLine("Create a account with a balance");
                                        double balance = double.Parse(Console.ReadLine());
                                        string type = "Savings";
                                        accounts = new Account() { AccountHolder = accountName, Balance = balance, AccountType = type };
                                        bankRepository.CreateAccount(accounts);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        Account accounts = new Account();
                                        Console.WriteLine("Enter you customer Id:");
                                        string currentStringId = Console.ReadLine();
                                        int currentaccountName = 0;
                                        InvalidAccountException.CheckIfInteger(currentStringId, ref currentaccountName);
                                        Console.WriteLine("Create a account with a balance");
                                        float currbal = float.Parse(Console.ReadLine());
                                        string currtype = "Current";
                                        accounts = new Account() { AccountHolder = currentaccountName, Balance = currbal, AccountType = currtype };
                                        bankRepository.CreateAccount(accounts);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                    break;
                                case 3:
                                    try
                                    {
                                        Account accounts = new Account();


                                        Console.WriteLine("Enter you customer Id:");
                                        string currentStringId = Console.ReadLine();
                                        int zeroBalanceName = 0;

                                        InvalidAccountException.CheckIfInteger(currentStringId, ref zeroBalanceName);
                                        Console.WriteLine("Create a account with a balance");
                                        float zerobal = float.Parse(Console.ReadLine());
                                        string zerotype = "Zero Balance";
                                        accounts = new Account() { AccountHolder = zeroBalanceName, Balance = zerobal, AccountType = zerotype };
                                        bankRepository.CreateAccount(accounts);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                case 4:
                                    goto Mainmenu;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option");
                                    goto Mainmenu;
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Deposit Money to your Account");
                            Console.WriteLine("Enter your Account Id ");
                            string depositId = Console.ReadLine();
                            Console.WriteLine("Enter your amount ");
                            float money = float.Parse(Console.ReadLine());
                            int dId = 0;

                            try
                            {
                                InvalidAccountException.CheckIfInteger(depositId, ref dId);
                                bankRepository.Deposit(dId, money);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Withdraw Money from your Account");
                            Console.WriteLine("Enter your Account Id ");
                            string withdrawId = Console.ReadLine();
                            Console.WriteLine("Enter your amount ");
                            float withdrawAmount = float.Parse(Console.ReadLine());
                            int dId1 = 0;
                            try
                            {
                                InvalidAccountException.CheckIfInteger(withdrawId, ref dId1);
                                bankRepository.Withdraw(dId1, withdrawAmount);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter Your Account Id to Get the balance ");

                            long balId = Convert.ToInt32(Console.ReadLine());
                            bankRepository.GetAccountBalance(balId);
                            break;
                        case 5:
                            Console.WriteLine("Transfer Your amount to your Friends and family");
                            Console.WriteLine("Enter Your Account id");
                            int sender = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter The account id you want to send the money to :");
                            int receiver = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Amount you want to Transfer");
                            float transferAmount = float.Parse(Console.ReadLine());
                            bankRepository.TransferAmount(sender, receiver, transferAmount);
                            break;
                        case 6:
                            Console.WriteLine("Enter your Account Id");
                            string getAccId = Console.ReadLine();
                            int aId = 0;
                            try
                            {
                                InvalidAccountException.CheckIfInteger(getAccId, ref aId);
                                bankRepository.GetAccountDetails(aId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 7:
                            Console.WriteLine("Displaying all the Accounts in the Bank");
                            Console.WriteLine("------------------------------");

                            List<Account> list = new List<Account>();
                            list = bankRepository.ListAccounts();
                            foreach (Account listall in list)
                                Console.WriteLine(listall);
                            break;
                        case 8:
                            Console.WriteLine("Calculating the interest ");
                            Console.WriteLine("Enter the Account Id you want to Calculate");//int interestId = Convert.ToInt32(Console.ReadLine());
                            string interestId = Console.ReadLine();
                            bankRepository.CalculateInterest(interestId);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice.Please Enter a Valid Choice");
                            break;
                    }
                }
            }

        }
    }

}
