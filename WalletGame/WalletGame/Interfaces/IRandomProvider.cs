﻿using System;

namespace WalletGameApp
{
    public interface IRandomProvider
    {
        int Next(int minValue, int maxValue);
        double NextDouble();
    }
}