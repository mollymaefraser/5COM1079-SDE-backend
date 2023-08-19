using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    public class Accounts
    {

        public static Tuple<string, string> CreateAccountDetails(User user)
        {
            //First Name
            Console.WriteLine("Please enter your First Name");
            user.FirstName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(user.FirstName))
            {
                Console.WriteLine("This field is required, please enter your First Name.");
                user.FirstName = Console.ReadLine();
            }

            //Last Name
            Console.WriteLine("Please enter your Last Name");
            user.LastName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(user.LastName))
            {
                Console.WriteLine("This field is required, please enter your Last Name.");
                user.LastName = Console.ReadLine();
            }

            //Email Address
            Console.WriteLine("Please enter your email address");
            user.Email = Console.ReadLine();
            while (IsEmailValid(user.Email) == false)
            {
                Console.WriteLine("Email address is invalid, please enter another email address");
                user.Email = Console.ReadLine();
            }

            //Password
            bool passwordsMatch = false;

            Console.WriteLine("Please create a password");
            user.Password = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(user.Password))
            {
                Console.WriteLine("This field is required, please enter your password.");
                user.Password = Console.ReadLine();
            }

            Console.WriteLine("Please confirm the password");
            string confirmedPassword = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(confirmedPassword))
            {
                Console.WriteLine("This field is required, please confirm your password.");
                confirmedPassword = Console.ReadLine();
            }

            while (passwordsMatch == false)
            {
                if (user.Password != confirmedPassword)
                {
                    Console.WriteLine("Passwords do not match, please re-enter");
                    confirmedPassword = Console.ReadLine();
                }
                else
                {
                    passwordsMatch = true;
                }
            }
            Console.WriteLine("Thank you for creating an account with MedIntelligence!");
            return Tuple.Create(user.Email, user.Password);
        }

        public void LogIntoAccount(User user)
        {
            var (exisitingEmail, correctPassword) = CreateAccountDetails(user);

            //Email Address
            Console.WriteLine("Please enter your email address");
            string enteredEmail = Console.ReadLine();
            while (enteredEmail != exisitingEmail)
            {
                Console.WriteLine("This email does not exisit at MedIntelligence. Please try another email or create an account with us.");
                enteredEmail = Console.ReadLine();
            }


            //Password
            Console.WriteLine("Please enter your password");
            string enteredPassword = Console.ReadLine();
            while (enteredPassword != correctPassword)
            {
                Console.WriteLine("Password Incorrect. Try Again");
                enteredPassword = Console.ReadLine();
            }
            Console.WriteLine("Successful login!");
        }

        public static bool IsEmailValid(string email)
        {
            bool isEmailValid;
            var emailAddresses = new List<string>
            {
                // Valid email addresses
                "eleanor@example.com",
                "eleanor.warren@example.net",
                "eleanor@example.co.uk",
                "eleanor@example",

                // Invalid email addresses
                "eleanor.example.com",
                "eleanor@warren@example.net",
                "eleanor@.example.co.uk",
                "eleanor"
            };

            string isValid = IsValid(email) ? "Valid" : "Invalid";
            if (isValid == "Valid")
            {
                isEmailValid = true;
            }
            else
            {
                isEmailValid = false;
            }
            return isEmailValid;
        }

        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}
