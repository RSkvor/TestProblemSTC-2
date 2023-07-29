namespace TestProblemSTC_2.Main.Providers
{
    public interface IPathProvider
    {
        public string InputFileFullPath { get; }
        public string OutputFileFullPath { get; }
    }
}