namespace Password_Validation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" please enter your password");
            string password = Console.ReadLine();
            bool isValid = true;
            //check length of password
            if(password.Length <8)
            {
                isValid = false;
            }
            //check for upper case
            bool hasUpperCase = false;
            foreach(char c in password)
            {
                if(char.IsUpper(c))
                {
                    hasUpperCase = true;
                    break;
                }
            }
            if(!hasUpperCase)
            {
                isValid = false;
            }
            //check for digit
            bool hasDigit = false;
            foreach(char ch in password)
            {
                if(char.IsDigit(ch))
                {
                    hasDigit = true;
                }
            }
            if(!hasDigit)
            {
                isValid = false;
            }
            if(isValid)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                Console.WriteLine("Password is Invalid");
            }

        }
    }
}
