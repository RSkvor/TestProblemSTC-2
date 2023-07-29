using TestProblemSTC_2.Main.Service;

namespace TestProblemSTC_2.Main.Providers
{
    internal class PathProvider : IPathProvider
    {
        public PathProvider()
        {
            if (!File.Exists(InputFileFullPath))
            {
                using var input = File.Create(InputFileFullPath);
            }

            if (!File.Exists(OutputFileFullPath))
            {
                using var output = File.Create(OutputFileFullPath);
            }
        }

        public string InputFileFullPath => Path.Combine(Environment.CurrentDirectory, "Input.txt");
        public string OutputFileFullPath => Path.Combine(Environment.CurrentDirectory, "Output.txt");
    }
}