namespace TestProblemSTC_2.Collections
{
    /// <inheritdoc/>
    internal class ExchangeCoinCollection : IExchangeCoinCollection
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