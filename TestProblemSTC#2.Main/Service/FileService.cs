using TestProblemSTC_2.Collections;
using TestProblemSTC_2.Providers;

namespace TestProblemSTC_2.Service
{
    /// <summary>
    /// Класс работы с тестовыми файлами
    /// </summary>
    internal class FileService : IFileService
    {
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;

        public FileService(IPathProvider pathProvider)
        {
            _inputFilePath = pathProvider.InputFilePath;
            _outputFilePath = pathProvider.OutputFilePath;
        }

        public ExchangeCoinCollection FileReader()
        {
            ExchangeCoinCollection exchangeCoinParameters;
            using (var reader = new StreamReader(_inputFilePath))
            {
                exchangeCoinParameters = new ExchangeCoinCollection(
                    sumCash: Convert.ToInt32(reader.ReadLine()),
                    coins: reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList());
            }
            return exchangeCoinParameters;
        }

        public void FileWriter(MinimalCoinCollection coinCollection)
        {
            using (var writer = new StreamWriter(_outputFilePath))
            {
                writer.WriteLine(coinCollection.Count);
                writer.WriteLine(string.Join(' ', coinCollection));
            }
        }
    }
}
