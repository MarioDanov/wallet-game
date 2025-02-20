# WalletGame

WalletGame is a .NET Core console application that simulates a player's wallet and a simple betting game. Players can deposit funds, withdraw funds, and place bets with outcomes determined by configurable game rules.

## Features

- **Wallet Management**
  - Start with an initial balance of $0.
  - Deposit and withdraw funds.
  - View the updated balance after each operation.

- **Betting Game**
  - Place bets within a specified range.
  - Game outcomes:
    - **Lose:** 50% chance, no win.
    - **Standard Win:** 40% chance, win with a multiplier between 1 and 2.
    - **Jackpot Win:** 10% chance, win with a multiplier between 2 and 10.
  - Balance is updated based on the bet amount and win amount.

- **Configurable Rules**
  - Game settings (bet limits, win/loss thresholds, multipliers) are defined in a configuration file for easy adjustments.

- **Robust Input Validation**
  - User input is validated with retry loops and clear error messages to ensure a smooth experience.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later is recommended)

### Setup

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/MarioDanov/wallet-game.git

