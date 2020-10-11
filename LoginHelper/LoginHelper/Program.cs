using System;

namespace UsernameValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many accounts would you like to register?");

            var accountList = new string[int.Parse(Console.ReadLine()), 2];

            for (int i = 0; i < accountList.GetLength(0); i++)
            {
                Console.WriteLine("Please, enter a username.");
                accountList[i, 0] = Console.ReadLine();
                Console.WriteLine("Please, enter a password.");
                accountList[i, 1] = Console.ReadLine();
            }

            Console.WriteLine("Please, enter a username to log in.");
            var username = Console.ReadLine();
            var matchingUsername = IsUsernameValid(username, accountList);

            if (matchingUsername != -1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Please, enter the password of the username " + accountList[matchingUsername, 0] + ".");
                    var password = Console.ReadLine();

                    if (password == accountList[matchingUsername, 1])
                    {
                        Console.WriteLine("Welcome, " + accountList[matchingUsername, 0] + "!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Password doesn't match, you have " + (3 - (i + 1)) + " more tries.");
                    }
                }

                Console.WriteLine("If you want to reset the password for the user " + accountList[matchingUsername, 0] + ", please type Y, if you want to exit, type N.");
                var exitOrReset = Console.ReadLine();

                if (exitOrReset == "Y")
                {
                    Console.WriteLine("Please, enter a new password.");
                    var newPassword = Console.ReadLine();

                    accountList[matchingUsername, 1] = newPassword;

                    Console.WriteLine("Password successfully reset. Please enter the new password to log in.");
                    var password = Console.ReadLine();

                    if (password == accountList[matchingUsername, 1])
                    {
                        Console.WriteLine("Welcome, " + accountList[matchingUsername, 0] + "!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("The password is incorrect again, LEAVE AND NEVAH COME BACK!!!");
                    }
                }
            }
            else
            {
                Console.WriteLine("We didn't find a matching username, sorry. :(");
            }
        }

        static int IsUsernameValid(string username, string[,] accountList)
        {
            for (int i = 0; i < accountList.GetLength(0); i++)
            {
                if (username == accountList[i, 0])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
