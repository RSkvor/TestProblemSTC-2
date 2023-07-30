namespace TestProblemSTC_2.Main.Providers
{
    /// <summary>
    /// Файловый репозиторий.
    /// Получает данные на ход из файла InputFileFullPath.
    /// Записывает данные на выход в файл OutputFileFullPath.
    /// </summary>
    public interface IPathProvider
    {
        /// <summary>
        /// Путь до файла с данными на вход
        /// </summary>
        public string InputFileFullPath { get; }

        /// <summary>
        /// Путь до файла с данными на выход
        /// </summary>
        public string OutputFileFullPath { get; }
    }
}