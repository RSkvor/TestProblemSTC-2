using TestProblemSTC_2.Main.Collections;

namespace TestProblemSTC_2.Main.Service
{
    internal interface IFileService
    {
        public ExchangeCoinCollection FileReader();

        public void FileWriter(MinimalCoinCollection coinCollection);
    }
}
