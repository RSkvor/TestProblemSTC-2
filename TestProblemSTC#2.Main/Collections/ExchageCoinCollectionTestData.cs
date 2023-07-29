namespace TestProblemSTC_2.Main.Collections
{
    /// <inheritdoc/>
    internal class ExchageCoinCollectionTestData : IExchangeCoinCollection
    {
        /// <inheritdoc/>
        public int SumCash => 22;

        /// <inheritdoc/>
        public List<int> Coins => new List<int>() { 1, 3, 5 };
    }
}