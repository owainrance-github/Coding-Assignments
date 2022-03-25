using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    class Program
    {
        public static void Main(string[] args)
        {
            int accountNumber = 0;
            int pin = 0;
            int correctPin = 0;
            bool matchPin = false;
            int withdraw = 0;
            int balance = 0;
            int newBalance = 0;
            int atmBalance = 9500;

            Console.WriteLine("ATM");
            Console.WriteLine("---------------------------------------------------");

            try
            {
                Console.WriteLine("Please input your account number, and then press Enter.");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                int checkAccount = accountNumber.ToString().Length;
                if (checkAccount == 8) 
                {
                    Console.WriteLine("Account number is valid");

                    var accountPin = new Dictionary<int, int>();
                    accountPin = GetAccountsAndPins();

                    var accountBalance = new Dictionary<int, int>();
                    accountBalance = GetAccountBalances();

                    if (accountPin.ContainsKey(accountNumber))
                    {
                        Console.WriteLine("Account matched.");

                        Console.WriteLine("Please input your pin number, and then press Enter.");
                        pin = Convert.ToInt32(Console.ReadLine());

                        int checkPin = pin.ToString("D4").Length;

                        if (checkPin == 4)
                        {
                            Console.WriteLine("Pin is valid.");

                            foreach(KeyValuePair<int, int> pair in accountPin)
                            {
                                if(pin == pair.Value)
                                {
                                    correctPin = pair.Value;
                                    matchPin = true;
                                }
                            }

                            if (matchPin)
                            {
                                Console.WriteLine("Pin matched");

                                balance = accountBalance[accountNumber];

                                Console.WriteLine($"ATM cash available: {atmBalance}");
                                Console.WriteLine("");
                                Console.WriteLine($"{accountNumber.ToString("D8")} {pin.ToString("D4")} {correctPin.ToString("D4")}");
                                Console.WriteLine("");

                                Console.WriteLine($"Welcome to you account. Please choose a service:");
                                Console.WriteLine("\tW - Withdraw");
                                Console.WriteLine("\tB - Balance");
                                Console.WriteLine("\t  - End Session");

                                switch (Console.ReadLine())
                                {
                                    case "W":
                                        Console.WriteLine($"How much would you like to withdraw?   Available funds: {balance}");
                                        withdraw = Convert.ToInt32(Console.ReadLine());

                                        if(withdraw < atmBalance)
                                        {
                                            if (withdraw < balance)
                                            {
                                                newBalance = balance - withdraw;

                                                balance = newBalance;

                                                Console.WriteLine($"Withdraw successful. Your new balance is: {balance}.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("FUNDS_ERR");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("ATM_ERR");
                                        }
                                        break;
                                    case "B":
                                        Console.WriteLine($"Your current balance is {balance}.");
                                        break;
                                    case "":
                                        Console.WriteLine("Session terminated.");
                                        break;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("ACCOUNT_ERR");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ACCOUNT_ERR");
                    }


                }
                else
                {
                    Console.WriteLine("ACCOUNT_ERR");
                }
            }
            catch
            {
                Console.WriteLine("ACCOUNT_ERR");
            }
            

            
            
        }

        public static Dictionary<int, int> GetAccountsAndPins()
        {
            var accountPin = new Dictionary<int, int>();

            accountPin.Add(12345678, 0987);
            accountPin.Add(87654321, 1234);
            accountPin.Add(99887766, 5678);
            accountPin.Add(54321987, 7431);
            accountPin.Add(76908721, 3887);
            accountPin.Add(60908321, 9546);

            return accountPin;

        }

        public static Dictionary<int, int> GetAccountBalances()
        {
            var accountBalance = new Dictionary<int, int>();

            accountBalance.Add(12345678, 8000);
            accountBalance.Add(87654321, 1000);
            accountBalance.Add(99887766, 10000);
            accountBalance.Add(54321987, 500);
            accountBalance.Add(76908721, 40);
            accountBalance.Add(60908321, 6000);

            return accountBalance;
        }
    }
}
