namespace TestProblemSTC_2.Providers
{
    public class PathProvider : IPathProvider
    {
        public string InputFilePath => @"Resources\Input.txt";
        public string OutputFilePath => @"Resources\Output.txt";
        public string RootDirectoryPath => Environment.CurrentDirectory;
    }
}