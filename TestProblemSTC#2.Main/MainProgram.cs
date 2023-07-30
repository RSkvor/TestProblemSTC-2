using Ninject;
using System.Globalization;
using TestProblemSTC_2.Main.Algorithms;
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

            if (exchangeCoinCollection.Coins.Count == 0)
            {
                Console.WriteLine("Были введены некорректные данные, программа была остановлена");
                Reminder();
                return;
            }
            
            if (exchangeCoinCollection.SumCash < 0)
            {
                Console.WriteLine("Сумма денег не может быть отрицательной.");
                Reminder();
                return;
            }

            var algorithm = Kernel.Get<IAlgorithm>();

            var minimalCoinCollector = algorithm.GetMinimalCoins(exchangeCoinCollection);

            fileService.FileWriter(minimalCoinCollector);

            Console.ReadLine();
        }

        /// <summary>
        /// Напоминалка, для тех, кто некорректно вводит данные в файлик.
        /// </summary>
        private static void Reminder()
        {
            Console.WriteLine("Напоминание о том как следует вводить данные: в первой строке - сумма монет, целое, неотрицательное число,");
            Console.WriteLine("во второй строке - список целых неотрицательных чисел (монет) через пробел, монет должно быть хотя бы одна.");
            Console.WriteLine("Для продолжения - нажмите Enter");
            Console.ReadLine();
        }
    }
}