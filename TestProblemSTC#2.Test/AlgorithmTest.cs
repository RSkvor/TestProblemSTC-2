using NUnit.Framework;
using Ninject;
using System.Globalization;
using TestProblemSTC_2.Main.Modules;

namespace TestProblemSTC_2.Test
{
    public class AlgorithmTest
    {
        public static IKernel Kernel;
        [SetUp]
        public void Init()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("ru-ru");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("ru-ru");

            Kernel = new StandardKernel(new BaseCommonModule());


        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}