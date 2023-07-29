using TestProblemSTC_2.Main.Collections;

namespace TestProblemSTC_2.Main.Algorithms
{
    internal class DPAlgorithm : IAlgorithm
    {
        public ICoinCollection GetMinimalCoins(IExchangeCoinCollection exchangeCoin)
        {
            if (exchangeCoin is null)
            {
                throw new ArgumentNullException(nameof(exchangeCoin));
            }

            var DPArray = FillDPArray(exchangeCoin);

            if (DPArray[exchangeCoin.SumCash] == exchangeCoin.SumCash + 1)
            {
                return new MinimalCoinCollection( new List<int>());
            }
            var usingCoins = new MinimalCoinCollection(RestoreCoins(exchangeCoin, DPArray));

            return usingCoins;
        }

        private static int[] FillDPArray(IExchangeCoinCollection exchangeCoin)
        {
            var dpArray = new int[exchangeCoin.SumCash + 1];

            for (int i = 1; i <= exchangeCoin.SumCash; i++)
            {
                var min = exchangeCoin.SumCash + 1;
                foreach (var coin in exchangeCoin.Coins)
                {
                    if (i < coin)
                    {
                        break;
                    }

                    if (i == coin)
                    {
                        min = 1;
                        break;
                    }

                    min = Math.Min(min, dpArray[i - coin] + 1);
                }

                dpArray[i] = min;
            }

            return dpArray;
        }

        private static List<int> RestoreCoins(
            IExchangeCoinCollection exchangeCoin,
            int[] dpArray)
        {
            var usingCoins = new List<int>();
            var lastSumCoins = exchangeCoin.SumCash;
            while (lastSumCoins > 0) 
            {
                foreach (var coin in exchangeCoin.Coins)
                {
                    if (coin > lastSumCoins) 
                        continue;
                    if (dpArray[lastSumCoins] - dpArray[lastSumCoins - coin] == 1)
                    {
                        usingCoins.Add(coin);
                        lastSumCoins -= coin;
                        continue;
                    }
                }
            }

            return usingCoins;
        }
    }
}