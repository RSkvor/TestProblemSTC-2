using Ninject;
using System.Globalization;

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
            

        }
    }
}