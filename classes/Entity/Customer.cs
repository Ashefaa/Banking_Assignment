using System;


namespace classes.Entity
{
    public class Customer
    {
        #region task 7 question 1
         string customerId;
         string firstName;
         string lastName;
         string emailAddress;
         string phoneNumber;
         string address;
         //default constructor
         public Customer()
         {

         }
         //Parameterized Constructor
        public Customer(string customerId,string firstName,string lastName,string emailAddress,string phoneNumber,string address)
         {
             this.customerId = customerId;
             this.firstName = firstName;
             this.lastName = lastName;
             this.emailAddress = emailAddress;
             this.phoneNumber = phoneNumber;
             this.address = address;
         }
         //getter and setter
         public string CustomerId
         {
             get { return customerId; }
             set { customerId = value; }
         }
         public string FirstName
         {
             get { return firstName; }
             set { firstName = value; }
         }
         public string LastName
         {
             get { return lastName; }
             set { lastName = value; } 
         }
         public string EmailAddress
         {
             get { return emailAddress; }
             set { emailAddress = value; }
         }
         public string PhoneNumber
         {
             get { return phoneNumber; }
             set { phoneNumber = value; }
         }
         public string Address
         {
             get { return address; }
             set { address = value; }
         }
         //to print all the customer information
         public void PrintCustomerInfo()
         {
             Console.WriteLine($"Customer ID ::{customerId}");
             Console.WriteLine($"First Name ::{firstName}");
             Console.WriteLine($"Last Name ::{lastName}");
             Console.WriteLine($"Email Address ::{emailAddress}");
             Console.WriteLine($"Phone Number ::{phoneNumber}");
             Console.WriteLine($"Address :: {address}");
         }
        #endregion
        #region Task 10 question 1
        //private int customerid;
        //private string firstName;
        //private string lastName;
        //private string emailId;
        //private string phoneNo;
        //private string address;

        //public int CustomerId
        //{
        //   get { return customerId; }
        //    set { customerId = value; }
        //}
        //public string FirstName
        //{ get { return firstName; }
        //    set { firstName = value; }
        //}
        //public string LastName
        //{
        //    get { return lastName; }
        //    set { lastName = value; }
        //}
        //public string EmailId
        //{
        //    get { return emailId; }
        //    set
        //    {
        //        if(IsValidEmail(value))
        //        {
        //            emailId = value;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid email");
        //        }
        //    }
        //}
        //public string PhoneNo
        //{
        //    get { return phoneNo; }
        //    set
        //    {
        //        if(IsValidPhoneNo(value))
        //        {
        //            phoneNo = value;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid Phone Number");
        //        }
        //    }
        //}
        //public string Address
        //{ get { return address; }
        //   set { address = value; } 
        //}

        ////default constructor
        //public Customer()
        //{ }
        ////parameterized constructor
        //public Customer(int customerId,string firstName,string lastName,string emailId,string phoneNo,string address)
        //{
        //    CustomerId = customerId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    EmailId = emailId;
        //    PhoneNo = phoneNo;
        //    Address = address;
        //}
        //public bool IsValidEmail(string emailId)
        //{
        //    string pattern = @"^[a-zA-Z0-9._%=-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        //    return Regex.IsMatch(emailId, pattern);
        //}
        //public bool IsValidPhoneNo(string phoneNo)
        //{
        //    string pattern = @"^\d{10}$";
        //    return Regex.IsMatch(phoneNo, pattern);
        //}
        //public void printCustomer()
        //{
        //    Console.WriteLine($"Customer Id:{customerId}");
        //    Console.WriteLine($"First Name:{firstName}");
        //    Console.WriteLine($"Last Name:{lastName}");
        //    Console.WriteLine($"Email ID:{emailId}");
        //    Console.WriteLine($"Phone No:{phoneNo}");
        //    Console.WriteLine($"Address:{address}");
        //}
        #endregion
        #region task 10 question 2,question 3

        //public string Name
        //{ get; }
        //public string Address
        //{ get; }
        //public long CustomerId { get; internal set; }

        //public Customer(string name,string address)
        //{
        //    Name = name;
        //    Address = address;
        //}
        //public override string ToString()
        //{
        //    return $"Name:{Name}- Address:{Address}";

        //}
#endregion
    }
}
