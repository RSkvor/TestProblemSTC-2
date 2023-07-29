using TestProblemSTC_2.Main.Collections;
using TestProblemSTC_2.Main.Providers;

namespace TestProblemSTC_2.Main.Service
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
            _inputFilePath = pathProvider.InputFileFullPath;
            _outputFilePath = pathProvider.OutputFileFullPath;
        }

        public ExchangeCoinCollection FileReader()
        {
            var inputFileInfo = new FileInfo(_inputFilePath); 

            if (inputFileInfo.Length == 0) 
            {
                FillEmptyFile(_inputFilePath);
            }

            ExchangeCoinCollection exchangeCoinParameters;
            using (var reader = new StreamReader(_inputFilePath))
            {
                exchangeCoinParameters = new ExchangeCoinCollection(
                    sumCash: Convert.ToInt32(reader.ReadLine()),
                    coins: reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList());
            }
            return exchangeCoinParameters;
        }

        public void FileWriter(ICoinCollection coinCollection)
        {
            using (var writer = new StreamWriter(_outputFilePath))
            {
                if (coinCollection.Count == 0)
                {
                    writer.WriteLine("-99");
                }
                else
                {
                    writer.WriteLine(coinCollection.Count);
                    writer.WriteLine(string.Join(' ', coinCollection));
                }
            }
        }

        private void FillEmptyFile(string emptyFile)
        {
            var baseCoinCollection = new ExchageCoinCollectionTestData();

            using (var writer = new StreamWriter(emptyFile))
            {
                writer.WriteLine(baseCoinCollection.SumCash);
                writer.WriteLine(string.Join(' ', baseCoinCollection.Coins));
            }
        }
    }
}
