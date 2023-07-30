using NUnit.Framework;
using Ninject;
using System.Globalization;
using TestProblemSTC_2.Main.Modules;
using TestProblemSTC_2.Main.Collections;
using TestProblemSTC_2.Main.Algorithms;

namespace TestProblemSTC_2.Test
{
    [TestFixture]
    public class AlgorithmTest
    {
        public static IKernel Kernel;

        private readonly IExchangeCoinCollection _exchangeCoinCollection_test1 = new ExchangeCoinCollection(
            7,
            new List<int>() { 2, 4, 6 });
        
        private readonly IExchangeCoinCollection _exchangeCoinCollection_test2 = new ExchangeCoinCollection(
            100,
            new List<int>() { 1, 4, 9, 10, 15, 21 });

        private readonly IExchangeCoinCollection _exchangeCoinCollection_test3 = new ExchangeCoinCollection(
            8,
            new List<int>() { 1, 4, 5 });

        private readonly IExchangeCoinCollection _exchangeCoinCollection_test4 = new ExchangeCoinCollection(
            0,
            new List<int>() { 1 });

        [SetUp]
        public void Init()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("ru-ru");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("ru-ru");

            Kernel = new StandardKernel(new BaseCommonModule());
        }

        [Test(Description = "Тест с недостижимой суммой")]
        public void TestMethod1()
        {
            var algorithm = Kernel.Get<IAlgorithm>();
            var a = algorithm.GetMinimalCoins(_exchangeCoinCollection_test1);

            Assert.IsNotNull(a);
            Assert.AreEqual(-99, a.CountCoinAnswer);
        }

        [Test(Description = "Тест рандом")]
        public void TestMethod2()
        {
            var algorithm = Kernel.Get<IAlgorithm>();
            var a = algorithm.GetMinimalCoins(_exchangeCoinCollection_test2);

            Assert.IsNotNull(a);
            Assert.AreEqual(6, a.CountCoinAnswer);
        }

        [Test(Description = "Тест с коварной суммой (жадный алгоритм без доп. обработок ответ не справился бы)")]
        public void TestMethod3()
        {
            var algorithm = Kernel.Get<IAlgorithm>();
            var a = algorithm.GetMinimalCoins(_exchangeCoinCollection_test3);

            Assert.IsNotNull(a);
            Assert.AreEqual(2, a.CountCoinAnswer);
        }

        [Test(Description = "Тест с нулевой суммой")]
        public void TestMethod4()
        {
            var algorithm = Kernel.Get<IAlgorithm>();
            var a = algorithm.GetMinimalCoins(_exchangeCoinCollection_test4);

            Assert.IsNotNull(a);
            Assert.AreEqual(0, a.CountCoinAnswer);
            Assert.AreEqual(0, a.Coins[0]);
        }
    }
}