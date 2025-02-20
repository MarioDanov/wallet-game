using System;

namespace WalletGameApp
{
    // Wallet Management: Handles deposits, withdrawals, and balance updates.
    public class Wallet
    {
        private decimal balance;

        public Wallet()
        {
            balance = 0m;
        }

        public decimal Balance => balance;

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > balance)
            {
                return false; // Insufficient funds.
            }
            balance -= amount;
            return true;
        }

        // Adjusts the balance after a bet is resolved.
        public void UpdateAfterBet(decimal winAmount)
        {
            balance += winAmount;
        }
    }
}