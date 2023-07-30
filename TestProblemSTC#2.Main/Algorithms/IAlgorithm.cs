using TestProblemSTC_2.Main.Collections;

namespace TestProblemSTC_2.Main.Algorithms
{
    /// <summary>
    /// Интерфейс алгоритмов для нахождения минимального количества монет на заданную сумму.
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchangeCoin"></param>
        /// <returns></returns>
        public ICoinCollection GetMinimalCoins(IExchangeCoinCollection exchangeCoin);
    }
}
