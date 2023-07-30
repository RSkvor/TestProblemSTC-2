using TestProblemSTC_2.Main.Collections;

namespace TestProblemSTC_2.Main.Service
{
    /// <summary>
    /// Сервис работы с тестовыми файлами.
    /// </summary>
    internal interface IFileService
    {
        /// <summary>
        /// Получение входных данных из файла.
        /// </summary>
        /// <returns>Разменщик монет с заданными параметрами.</returns>
        public ExchangeCoinCollection FileReader();

        /// <summary>
        /// Запись ответа в файл.
        /// </summary>
        /// <param name="coinCollection">Коллекция из минимального количества монет.</param>
        public void FileWriter(ICoinCollection coinCollection);
    }
}
