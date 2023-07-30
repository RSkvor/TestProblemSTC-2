using TestProblemSTC_2.Main.Service;

namespace TestProblemSTC_2.Main.Providers
{
    /// <summary>
    /// Основной файловый репозиторий
    /// </summary>
    internal class PathProvider : IPathProvider
    {
        public PathProvider()
        {
            // Если файлов нет - создаем
            if (!File.Exists(InputFileFullPath))
            {
                using var input = File.Create(InputFileFullPath);
            }

            if (!File.Exists(OutputFileFullPath))
            {
                using var output = File.Create(OutputFileFullPath);
            }
        }

        /// <inheritdoc/>>
        public string InputFileFullPath => Path.Combine(Environment.CurrentDirectory, "Input.txt");
        
        /// <inheritdoc/>>
        public string OutputFileFullPath => Path.Combine(Environment.CurrentDirectory, "Output.txt");
    }
}