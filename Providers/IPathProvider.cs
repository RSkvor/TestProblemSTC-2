namespace TestProblemSTC_2.Providers
{
    public interface IPathProvider
    {
        public string InputFileFullPath { get; }
        public string OutputFileFullPath { get; }
    }
}