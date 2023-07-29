namespace TestProblemSTC_2.Main.Collections
{
    /// <summary>
    /// Коллекция из разменных монет
    /// </summary>
    public interface ICoinCollection
    {
        /// <summary>
        /// Количество монет
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Перечень разменных монет
        /// </summary>
        public List<int> CoinCollection { get; }
    }
}
