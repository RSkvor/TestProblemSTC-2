namespace TestProblemSTC_2.Providers
{
    public interface IPathProvider
    {
        public string InputFilePath { get; }
        public string OutputFilePath { get; }
    }
}