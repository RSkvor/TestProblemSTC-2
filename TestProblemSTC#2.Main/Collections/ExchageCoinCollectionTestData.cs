namespace TestProblemSTC_2.Main.Collections
{
    /// <summary>
    /// Тестовый класс разменника монет.
    /// По сути - пример заданный из тестового задания.
    /// Нужен только если файлик пустой.
    /// </summary>
    internal class ExchageCoinCollectionTestData : IExchangeCoinCollection
    {
        /// <inheritdoc/>
        public int SumCash => 22;

        /// <inheritdoc/>
        public List<int> Coins => new List<int>() { 1, 3, 5 };
    }
}