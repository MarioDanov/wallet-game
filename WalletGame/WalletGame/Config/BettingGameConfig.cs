using System;


namespace WalletGameApp
{
    // Configuration settings for game rules.
    public static class BettingGameConfig
    {
        // Bet limits.
        public const decimal MIN_BET = 1m;
        public const decimal MAX_BET = 10m;

        // Outcome thresholds (using a random number between 0 and 99).
        // If outcome is less than LOSE_THRESHOLD, the player loses.
        // If outcome is between LOSE_THRESHOLD (inclusive) and WIN_THRESHOLD (exclusive),
        // the player wins with a standard multiplier.
        // If outcome is equal to or greater than WIN_THRESHOLD, the player wins with a jackpot multiplier.
        public const int LOSE_THRESHOLD = 50;
        public const int WIN_THRESHOLD = 90; // 50% lose, 40% standard win, 10% jackpot win.

        // Multipliers for a win outcome.
        public const decimal MIN_WIN_MULTIPLIER = 1m;
        public const decimal MAX_WIN_MULTIPLIER = 2m;

        // Multipliers for a jackpot outcome.
        public const decimal MIN_JACKPOT_MULTIPLIER = 2m;
        public const decimal MAX_JACKPOT_MULTIPLIER = 10m;
    }
}