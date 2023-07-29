using Ninject;
using System.Globalization;
using TestProblemSTC_2.Main.Algorithms;
using TestProblemSTC_2.Main.Collections;
using TestProblemSTC_2.Main.Modules;
using TestProblemSTC_2.Main.Service;

namespace TestProblemSTC_2.Main
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