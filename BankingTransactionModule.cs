using System;

namespace BankingApplication
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public decimal Deposit(decimal amount)
        {
            try
            {
                if (amount <= 0)
                    throw new ArgumentException("Deposit amount must be positive.");

                Balance += amount;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Balance;
        }

        public decimal Withdraw(decimal amount)
        {
            try
            {
                if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be positive.");

                if (amount > Balance)
                    throw new InvalidOperationException("Insufficient funds.");

                Balance -= amount;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Balance;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Account account = new Account();

            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("Enter the choice");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                return;

            Console.WriteLine("Enter the account number");
            account.AccountNumber = Console.ReadLine();

            Console.WriteLine("Enter the balance");
            account.Balance = ReadDecimal();

            if (choice == 1)
            {
                Console.WriteLine("Enter the amount to be deposit");
                decimal amount = ReadDecimal();
                Console.WriteLine("Balance amount " + account.Deposit(amount));
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the amount to be withdraw");
                decimal amount = ReadDecimal();
                Console.WriteLine("Balance amount " + account.Withdraw(amount));
            }
        }

        public static decimal ReadDecimal()
        {
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Enter a valid amount:");
            }
            return value;
        }
    }
}
