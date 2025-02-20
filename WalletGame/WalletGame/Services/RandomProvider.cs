using System;

namespace WalletGameApp
{
    // Production implementation using System.Random.
    public class RandomProvider : IRandomProvider
    {
        private readonly Random random;

        public RandomProvider()
        {
            random = new Random();
        }

        public int Next(int minValue, int maxValue) => random.Next(minValue, maxValue);
        public double NextDouble() => random.NextDouble();
    }
}