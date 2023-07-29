using TestProblemSTC_2.Main.Collections;

namespace TestProblemSTC_2.Main.Algorithms
{
    /// <summary>
    /// Интерфейс алгоритмов для нахождения минимального количества монет на заданную сумму.
    /// </summary>
    internal interface IAlgorithm
    {
        public List<int> GetMinimalCoins(ExchangeCoinCollection exchangeCoin);
    }
}
