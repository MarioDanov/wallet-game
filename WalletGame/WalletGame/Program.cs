using System;

namespace WalletGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet = new Wallet();

            IRandomProvider randomProvider = new RandomProvider();

            BettingGame game = new BettingGame(randomProvider);

            ConsoleUI ui = new ConsoleUI(wallet, game);
            ui.Run();
        }
    }
}