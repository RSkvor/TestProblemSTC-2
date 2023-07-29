using TestProblemSTC_2.Collections;

namespace TestProblemSTC_2.Algorithms
{
    internal class DPAlgorithm : IAlgorithm
    {
        public List<int> GetMinimalCoins(ExchangeCoinCollection exchangeCoin)
        {
            if (exchangeCoin is null)
            {
                throw new ArgumentNullException(nameof(exchangeCoin));
            }

            var DPArray = FillDPArray(exchangeCoin);
            var usingCoins = RestoreCoins(exchangeCoin, DPArray);

            return usingCoins;
        }

        private static int[] FillDPArray(ExchangeCoinCollection exchangeCoin)
        {
            var dpArray = new int[exchangeCoin.SumCash];

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

                    min = Math.Min(min, dpArray[i - coin]);
                }

                dpArray[i] = min;
            }

            return dpArray;
        }

        private static List<int> RestoreCoins(
            ExchangeCoinCollection exchangeCoin,
            int[] dpArray)
        {
            var usingCoins = new List<int>();
            var minCoins = dpArray[exchangeCoin.SumCash];
            var lastSumCoins = exchangeCoin.SumCash;
            for (int i = exchangeCoin.SumCash; i > 0; i--)
            {
                if (dpArray[i] == minCoins - 1)
                {
                    usingCoins.Add(lastSumCoins - i);
                    lastSumCoins = i;
                    minCoins--;
                }
            }

            return usingCoins;
        }
    }
}