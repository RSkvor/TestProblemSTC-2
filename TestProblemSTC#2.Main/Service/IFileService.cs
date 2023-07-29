using TestProblemSTC_2.Collections;

namespace TestProblemSTC_2.Service
{
    internal interface IFileService
    {
        public ExchangeCoinCollection FileReader();

        public void FileWriter(MinimalCoinCollection coinCollection);
    }
}
