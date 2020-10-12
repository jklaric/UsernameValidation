using System;
using System.Collections.Generic;

namespace UsernameValidation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many accounts would you like to register?");
            var listLength = int.Parse(Console.ReadLine());
            var accountList = new List<List<object>>();

            for (int i = 0; i < listLength; i++)
            {
                var input = new List<object>();
                Console.WriteLine("Please, enter a username.");
                input.Add(Console.ReadLine());
                Console.WriteLine("Please, enter a password.");
                input.Add(Console.ReadLine());
                Console.WriteLine("Please enter your phone number.");
                input.Add(int.Parse(Console.ReadLine()));

                accountList.Add(input);
            }

            Console.WriteLine("Please, enter a username to log in.");
            var username = Console.ReadLine();
            var matchingUsername = IsUsernameValid(username, accountList);

            if (matchingUsername != -1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Please, enter the password of the username " + accountList[matchingUsername][0] + ".");
                    var password = Console.ReadLine();

                    if (password == accountList[matchingUsername][1].ToString())
                    {
                        Console.WriteLine("Welcome, " + accountList[matchingUsername][0] + "!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Password doesn't match, you have " + (3 - (i + 1)) + " more tries.");
                    }
                }

                Console.WriteLine("If you want to reset the password for the user " + accountList[matchingUsername][0] + ", please type Y, if you want to exit, type N.");
                var exitOrReset = Console.ReadLine();

                if (exitOrReset == "Y")
                {
                    Console.WriteLine("Please enter your phone number to confirm possession of account.");

                    if (accountList[matchingUsername][2].Equals(int.Parse(Console.ReadLine())))
                    {
                        Console.WriteLine("Please, enter a new password.");
                        var newPassword = Console.ReadLine();
                        accountList[matchingUsername][1] = newPassword;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, we can't confirm that this account is yours. :(");
                    }

                    Console.WriteLine("Password successfully reset. Please enter the new password to log in.");
                    var password = Console.ReadLine();

                    if (password == accountList[matchingUsername][1].ToString())
                    {
                        Console.WriteLine("Welcome, " + accountList[matchingUsername][0] + "!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("The password is incorrect again, please try to reset the program and try again.");
                    }
                }
            }
            else
            {
                Console.WriteLine("We didn't find a matching username, sorry. :(");
            }
        }

        static int IsUsernameValid(string username, List<List<object>> accountList)
        {
            for (int i = 0; i < accountList.Count; i++)
            {
                if (username == accountList[i][0].ToString())
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
