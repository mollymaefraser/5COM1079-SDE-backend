using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    // TOM: This class is not needed, it's a good reference point but the actual process will be done over web API, not a console application.
    // As a step by step guide:
    // 1. Create a repository class within the Meditelligence.DataAccess.Repositories area. You can use the other classes in there as a reference.
    // 2. You need to create DTOs (data transfer objects) for the User class. You can ask me for help on this as it is a bit confusing to understand, but there are examples on my branch.
    // 3. Create a controller in the Meditelligence.WebAPI.Controllers folder. This is where the endpoints and the "communication with svelte" will occur.
    //    Effectively the website will send http requests to us, which will call our methodand then the processing will occur from there. You will need an endpoint for registration, logging in.
    //    Logging out I wouldn't worry about at all. Again, I have made some controllers already which you can use as a guide
    public class Accounts
    {

        // TOM: the parameter to this function should be a new object called UserCreateDto. This will have the same fields as the User object, minus any primary or foreign key attributes. 
        public static Tuple<string, string> CreateAccountDetails(User user)
        {
            // TOM: Note you do not have to do any actual manual input via Console.Readline etc. All of this will be provided from values entered in the front end. 

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

            // TOM: Note as well, you will not need to do password matching validation as the client side (website) can handle that. 
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

            // TOM: the final result of the operation should be making a new account record inside the database. I have done this with other tables in the Meditelligence.DataAccess.Repositories folder if you need a reference.
            return Tuple.Create(user.Email, user.Password);
        }


        // TOM: In terms of logging in, you will need to take in a email and password. All you need to do is check if the email is in the database. You will return a boolean saying whether or not user is admin, as well as the user ID.
        public void LogIntoAccount(User user)
        {
            var (exisitingEmail, correctPassword) = CreateAccountDetails(user);

            // TOM: Again this stuff will be client logic. It's good for reference, but if you set this up via web API endpoints, you could use swagger UI to run it and test it instead.
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

        // TOM: this will be handled by the client. Also note, Regular expression would be best for this as all emails follow a pattern of characters.
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

        // TOM: I think this code basically tells us that the other method is redundant as MailAddress appears to have built in email validation.
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
