// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using BitcoinLib.CoinParameters.Base;

namespace BitcoinLib.CoinParameters.XAYA
{
    public static class XAYAConstants
    {
        public sealed class Constants : CoinConstants<Constants>
        {
            // public readonly ushort CoinReleaseHalfsEveryXInYears = 4;
            // public readonly ushort DifficultyIncreasesEveryXInBlocks = 2016;
            public readonly uint OneCHIInCHItoshis = 100000000;
            public readonly decimal OneCHItoshiInCHI = 0.00000001M;
            public readonly decimal OneMicrocoinInCHI = 0.000001M;
            public readonly decimal OneMillicoinInCHI = 0.001M;
            public readonly string Symbol = "CHI";
        }
    }
}