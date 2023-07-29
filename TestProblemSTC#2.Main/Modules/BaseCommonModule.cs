using Ninject.Modules;
using TestProblemSTC_2.Algorithms;
using TestProblemSTC_2.Providers;
using TestProblemSTC_2.Service;

namespace TestProblemSTC_2.Modules
{
    internal class BaseCommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlgorithm>()
                .To<DPAlgorithm>()
                .InSingletonScope();

            Bind<IPathProvider>()
                .To<PathProvider>()
                .InSingletonScope();

            Bind<IFileService>()
                .To<FileService>()
                .InSingletonScope();
        }
    }
}
