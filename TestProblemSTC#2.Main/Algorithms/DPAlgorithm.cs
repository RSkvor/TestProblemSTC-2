using TestProblemSTC_2.Main.Collections;

namespace TestProblemSTC_2.Main.Algorithms
{
    /// <summary>
    /// Алгоритм динамического программирования.
    /// По сути своей позволяет находить лучший вариант за О(nk),
    /// где n - сумма, которую надо получить, а k - количество монет.
    /// </summary>
    internal class DPAlgorithm : IAlgorithm
    {
        /// <summary>
        /// Максимум, который недостижим в процессе выполнения алгоритма.
        /// </summary>
        protected int Max { get; private set; }

        /// <summary>
        /// Нахождение минимального набора монет.
        /// </summary>
        /// <param name="exchangeCoin">Заданный разменник монет.</param>
        /// <returns>Минимальный набор монет</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ICoinCollection GetMinimalCoins(IExchangeCoinCollection exchangeCoin)
        {
            if (exchangeCoin is null)
            {
                throw new ArgumentNullException(nameof(exchangeCoin));
            }

            // Задаем недостижимый максимум, хитрость в том, что минимальная монета может быть только 1.
            // Значит разменник может предложить под размен сумммы Х не более чем Х монет. 
            Max = exchangeCoin.SumCash + 1;

            // Заполняем массив при помощи динамики,
            // DPArray[Х] - минимальное кол-во монет для набора суммы Х.
            var DPArray = FillDPArray(exchangeCoin);

            // Тут небольшая магия 
            if (DPArray[exchangeCoin.SumCash] == Max)
            {
                // Если значение Max - то эту сумму никак не разменять.
                return new MinimalCoinCollection( new List<int>());
            }

            // Восстанавливаем цепочку набора монет (Для быстроты - можно было объединить 2 метода,
            // но я хотел чтобы каждый метод занимался своим делом).
            var usingCoins = new MinimalCoinCollection(RestoreCoins(exchangeCoin, DPArray));

            return usingCoins;
        }

        /// <summary>
        /// Метод заполнения массива.
        /// Тут используется динамика, думаю его комментировать не требуется.
        /// </summary>
        /// <param name="exchangeCoin">Заданный разменник монет.</param>
        /// <returns>Массив с минимальными разбиениями. dpArray[x] - разбивается минимум на Х монет.</returns>
        private static int[] FillDPArray(IExchangeCoinCollection exchangeCoin)
        {
            var dpArray = new int[exchangeCoin.SumCash + 1];
            dpArray[0] = 0;

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

        /// <summary>
        /// Восстанавливаем цепочку с минимальнымы монетами
        /// </summary>
        /// <param name="exchangeCoin">Заданный разменник монет.</param>
        /// <param name="dpArray">Массив с минимальными разбиениями. dpArray[x] - разбивается минимум на Х монет.</param>
        /// <returns>Список с минимальным количеством монет (несортированный, может быть в разнобой)</returns>
        private static List<int> RestoreCoins(
            IExchangeCoinCollection exchangeCoin,
            int[] dpArray)
        {
            var usingCoins = new List<int>();
            var lastSumCoins = exchangeCoin.SumCash;

            if ( lastSumCoins == 0)
            {   
                usingCoins.Add(0);
                return usingCoins;
            }

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