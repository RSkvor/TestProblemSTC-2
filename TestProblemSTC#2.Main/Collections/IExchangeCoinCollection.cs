namespace TestProblemSTC_2.Main.Collections
{
    /// <summary>
    /// Разменщик монет.
    /// Сюда попадают первоначальные условия.
    /// </summary>
    public interface IExchangeCoinCollection
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
