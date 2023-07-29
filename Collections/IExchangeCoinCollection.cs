using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProblemSTC_2.Collections
{
    /// <summary>
    /// Разменщик монет.
    /// Сюда попадают первоначальные условия.
    /// </summary>
    internal interface IExchangeCoinCollection
    {
        /// <summary>
        /// Сумма денег, которую требуется разменять 
        /// </summary>
        public int SumCash { get; }

        /// <summary>
        /// Номиналы денежных монет
        /// </summary>
        public List<int> Coins { get; }
    }
}
