namespace TestProblemSTC_2.Main.Collections
{
    /// <summary>
    /// Стандартный разменщик монет.
    /// Сюда попадают значения из входного файла.
    /// В конструкторе монеты сортируются по возрастанию.
    /// </summary>
    public class ExchangeCoinCollection : IExchangeCoinCollection
    {
        public ExchangeCoinCollection(
            int sumCash,
            List<int> coins)
        {
            if (coins is null)
            {
                throw new ArgumentNullException(nameof(coins));
            }

            SumCash = sumCash;

            // Монеты могут повториться в строке и быть неотсортированы,
            // потому стоит избавиться от дубликатов и отсортировать
            Coins = coins.Distinct().OrderBy(x => x).ToList();
        }

        /// <inheritdoc/>
        public int SumCash { get; }

        /// <inheritdoc/>
        public List<int> Coins { get; }
    }
}