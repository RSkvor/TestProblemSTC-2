using Ninject;
using System.Globalization;
using TestProblemSTC_2.Algorithms;
using TestProblemSTC_2.Collections;
using TestProblemSTC_2.Modules;
using TestProblemSTC_2.Providers;
using TestProblemSTC_2.Service;

namespace TestProblemSTC_2
{
    internal class MainProgram
    {
        public static IKernel Kernel;
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("ru-ru");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("ru-ru");

            Kernel = new StandardKernel(new BaseCommonModule());

            var fileService = Kernel.Get<IFileService>();

            var exchangeCoinCollection = fileService.FileReader();

            if (exchangeCoinCollection.SumCash < 1) 
            {
                fileService.FileWriter(new MinimalCoinCollection(new List<int>()));
                Console.ReadLine();
                return;
            }

            var algorithm = Kernel.Get<IAlgorithm>();

            var minimalCoinCollector = new MinimalCoinCollection(algorithm.GetMinimalCoins(exchangeCoinCollection));

            fileService.FileWriter(minimalCoinCollector);

            Console.ReadLine();
        }
    }
}