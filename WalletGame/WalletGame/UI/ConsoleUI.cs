using System;

namespace WalletGameApp
{
    public class ConsoleUI
    {
        private readonly Wallet wallet;
        private readonly BettingGame game;

        public ConsoleUI(Wallet wallet, BettingGame game)
        {
            this.wallet = wallet;
            this.game = game;
        }

        public void Run()
        {
            bool exit = false;
            Console.WriteLine("Welcome to the Gaming Wallet!");

            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleDeposit();
                        break;
                    case "2":
                        HandleWithdrawal();
                        break;
                    case "3":
                        HandleBet();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\n------------------------------");
            Console.WriteLine($"Current balance: ${wallet.Balance:F2}");
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Deposit funds");
            Console.WriteLine("2. Withdraw funds");
            Console.WriteLine($"3. Place a bet (between ${BettingGameConfig.MIN_BET} and ${BettingGameConfig.MAX_BET})");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice: //Ex: '1' - to deposit funds");
        }

        // Helper method to get valid decimal input from the user.
        private decimal GetValidDecimalInput(string prompt, Func<decimal, bool> validator, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal value) && validator(value))
                {
                    return value;
                }
                Console.WriteLine(errorMessage);
            }
        }

        private void HandleDeposit()
        {
            decimal amount = GetValidDecimalInput(
                "Enter deposit amount: ",
                x => x > 0,
                "Invalid input. Please enter a positive numeric value."
            );

            try
            {
                wallet.Deposit(amount);
                Console.WriteLine($"Deposited ${amount:F2}. New balance: ${wallet.Balance:F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void HandleWithdrawal()
        {
            decimal amount = GetValidDecimalInput(
                "Enter withdrawal amount: ",
                x => x > 0,
                "Invalid input. Please enter a positive numeric value."
            );

            try
            {
                if (wallet.Withdraw(amount))
                {
                    Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${wallet.Balance:F2}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds for the requested withdrawal.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void HandleBet()
        {
            decimal bet = GetValidDecimalInput(
                $"Enter bet amount (between ${BettingGameConfig.MIN_BET} and ${BettingGameConfig.MAX_BET}): ",
                x => x >= BettingGameConfig.MIN_BET && x <= BettingGameConfig.MAX_BET,
                $"Bet must be between ${BettingGameConfig.MIN_BET} and ${BettingGameConfig.MAX_BET}."
            );

            if (bet > wallet.Balance)
            {
                Console.WriteLine("Insufficient funds to place the bet.");
                return;
            }

            // Deduct the bet amount.
            if (!wallet.Withdraw(bet))
            {
                Console.WriteLine("Error withdrawing bet amount.");
                return;
            }

            // Play the round and get the win amount.
            decimal win = game.PlayRound(bet);
            wallet.UpdateAfterBet(win);

            if (win > 0)
            {
                Console.WriteLine($"Congratulations! You won ${win:F2}!");
            }
            else
            {
                Console.WriteLine("Sorry, you lost the bet.");
            }
            Console.WriteLine($"Your new balance is: ${wallet.Balance:F2}");
        }
    }
}