using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProblemSTC_2.Collections
{
    /// <inheritdoc/>
    internal class MinimalCoinCollection : ICoinCollection
    {
        public MinimalCoinCollection(List<int> coinCollection)
        {
            CoinCollection = coinCollection;
            Count = coinCollection.Count;
        }

        /// <inheritdoc/>
        public int Count { get; }

        /// <inheritdoc/>
        public List<int> CoinCollection { get; }
    }
}
