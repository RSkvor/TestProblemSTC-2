using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProblemSTC_2.Main.Collections
{
    /// <summary>
    /// Базовый класс для итоговой минимальной коллекции монет, из которых можно составить сумму монет.
    /// Нужен только для получения итогового ответа.
    /// </summary>
    internal class MinimalCoinCollection : ICoinCollection
    {
        /// <summary>
        /// Если коллекция пустая, то ответ - невозможно собрать коллекцию.
        /// </summary>
        private const int ImpossibleAnswer = -99;

        public MinimalCoinCollection(List<int> coinCollection)
        {
            Coins = coinCollection;
            // Руками отбрасываем исключительные случаи (невозможные и сумма 0)
            CountCoinAnswer = coinCollection.Count == 0 
                ? ImpossibleAnswer 
                : (coinCollection.Count == 1 && coinCollection[0] == 0) 
                    ? 0 
                    : coinCollection.Count;
        }

        /// <inheritdoc/>
        public int CountCoinAnswer { get; }

        /// <inheritdoc/>
        public List<int> Coins { get; }
    }
}
