namespace TestProblemSTC_2.Main.Collections
{
    /// <summary>
    /// Коллекция из разменных монет
    /// </summary>
    public interface ICoinCollection
    {
        /// <summary>
        /// Ответ количества монет в коллекции.
        /// Если монет в коллекции нет - их количество должно равняться -99.
        /// </summary>
        public int CountCoinAnswer { get; }

        /// <summary>
        /// Перечень разменных монет
        /// </summary>
        public List<int> Coins { get; }
    }
}
