using TestProblemSTC_2.Main.Collections;
using TestProblemSTC_2.Main.Providers;

namespace TestProblemSTC_2.Main.Service
{
    /// <summary>
    /// Основной сервис работы с тестовыми файлами.
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

        /// <summary>
        /// Получение входных данных из _inputFilePath.
        /// </summary>
        /// <returns>Разменщик монет с заданными параметрами.</returns>
        public ExchangeCoinCollection FileReader()
        {
            var inputFileInfo = new FileInfo(_inputFilePath); 

            if (inputFileInfo.Length == 0) 
            {
                // Если файл пустой - заполним его примером из задания. 
                FillEmptyFile();
            }

            ExchangeCoinCollection exchangeCoinParameters;
            using (var reader = new StreamReader(_inputFilePath))
            {
                try
                {
                    exchangeCoinParameters = new ExchangeCoinCollection(
                        sumCash: Convert.ToInt32(reader.ReadLine()),
                        coins: reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Исходные данные записаны некорректно.");
                    reader.Close();
                    return new ExchangeCoinCollection(0, new List<int>());
                }
            }
            return exchangeCoinParameters;
        }

        /// <summary>
        /// Запись ответа в файл _outputFilePath.
        /// </summary>
        /// <param name="coinCollection">Коллекция из минимального количества монет.</param>
        public void FileWriter(ICoinCollection coinCollection)
        {
            using (var writer = new StreamWriter(_outputFilePath))
            {
                writer.WriteLine(coinCollection.CountCoinAnswer);
                
                if (coinCollection.Coins.Count != 0) 
                { 
                    writer.WriteLine(string.Join(' ', coinCollection.Coins));
                }
            }

            Console.WriteLine($"Данные были записаны в файл: {_outputFilePath}");
            Console.WriteLine();
            Console.WriteLine($"Дублирую итоговый ответ:");

            if (coinCollection.Coins.Count != 0)
            {
                Console.WriteLine($"Минимальное количество монет - {coinCollection.CountCoinAnswer}");
                Console.WriteLine($"Минимальная коллекция монет: {string.Join(' ', coinCollection.Coins)}");
            }
            else
            {
                Console.WriteLine($"Нельзя составить предложенную сумму. Ответ: {coinCollection.CountCoinAnswer}");
            }
        }

        /// <summary>
        /// Заполняем пустой файл примером из тестового задания.
        /// </summary>
        private void FillEmptyFile()
        {
            var baseCoinCollection = new ExchageCoinCollectionTestData();

            using (var writer = new StreamWriter(_inputFilePath))
            {
                writer.WriteLine(baseCoinCollection.SumCash);
                writer.WriteLine(string.Join(' ', baseCoinCollection.Coins));
            }
        }
    }
}
