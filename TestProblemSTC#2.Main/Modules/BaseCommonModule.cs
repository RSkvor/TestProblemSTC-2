using Ninject.Modules;
using TestProblemSTC_2.Main.Algorithms;
using TestProblemSTC_2.Main.Collections;
using TestProblemSTC_2.Main.Providers;
using TestProblemSTC_2.Main.Service;

namespace TestProblemSTC_2.Main.Modules
{
    /// <summary>
    /// Модуль подключения библиотек к DI
    /// </summary>
    public class BaseCommonModule : NinjectModule
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

            Bind<ICoinCollection>()
                .To<MinimalCoinCollection>()
                .InSingletonScope();
        }
    }
}
