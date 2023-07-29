using TestProblemSTC_2.Collections;

namespace TestProblemSTC_2.Algorithms
{
    /// <summary>
    /// Интерфейс алгоритмов для нахождения минимального количества монет на заданную сумму.
    /// </summary>
    internal interface IAlgorithm
    {
        public List<int> GetMinimalCoins(ExchangeCoinCollection exchangeCoin);
    }
}
