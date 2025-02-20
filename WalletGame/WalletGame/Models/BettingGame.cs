using System;

namespace WalletGameApp
{
    public class BettingGame
    {
        private readonly IRandomProvider randomProvider;

        public BettingGame(IRandomProvider randomProvider)
        {
            this.randomProvider = randomProvider;
        }

        // Simulates one round of betting and returns the win amount.
        public decimal PlayRound(decimal bet)
        {
            if (bet < BettingGameConfig.MIN_BET || bet > BettingGameConfig.MAX_BET)
            {
                throw new ArgumentException($"Bet amount must be between ${BettingGameConfig.MIN_BET} and ${BettingGameConfig.MAX_BET}.");
            }

            int outcome = randomProvider.Next(0, 100);
            decimal winAmount = 0m;

            if (outcome < BettingGameConfig.LOSE_THRESHOLD)
            {
                // Lose condition.
                winAmount = 0m;
            }
            else if (outcome < BettingGameConfig.WIN_THRESHOLD)
            {
                // Standard win: multiplier between MIN_WIN_MULTIPLIER and MAX_WIN_MULTIPLIER.
                decimal multiplier = BettingGameConfig.MIN_WIN_MULTIPLIER +
                    (decimal)(randomProvider.NextDouble() * (double)(BettingGameConfig.MAX_WIN_MULTIPLIER - BettingGameConfig.MIN_WIN_MULTIPLIER));
                winAmount = bet * multiplier;
            }
            else
            {
                // Jackpot win: multiplier between MIN_JACKPOT_MULTIPLIER and MAX_JACKPOT_MULTIPLIER.
                decimal multiplier = BettingGameConfig.MIN_JACKPOT_MULTIPLIER +
                    (decimal)(randomProvider.NextDouble() * (double)(BettingGameConfig.MAX_JACKPOT_MULTIPLIER - BettingGameConfig.MIN_JACKPOT_MULTIPLIER));
                winAmount = bet * multiplier;
            }

            return winAmount;
        }
    }
}