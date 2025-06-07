using Moq;
using CoinVendingMachine.Repositories.Interfaces;
using CoinVendingMachine.Services;
using CoinVendingMachine.Models;
using CoinVendingMachine.Enums;
namespace CoinVendingMachineTestCoverage
{
    [TestFixture]
    public class CoinVendingMachineServiceTests
    {
        private Mock<ICoinRepository> _coinRepoMock;
        private Mock<IProductItemTypeRepository> _productRepoMock;
        private CoinVendingMachineService _service;

        [SetUp]
        public void SetUp()
        {
            _coinRepoMock = new Mock<ICoinRepository>();
            _productRepoMock = new Mock<IProductItemTypeRepository>();
            _service = new CoinVendingMachineService(_coinRepoMock.Object, _productRepoMock.Object);
        }

        [Test]
        public void Insert_Valid_Coin_Updates_Balance_And_Display()
        {
            var coin = new Coins { Type = CoinType.Dime } ;
            _coinRepoMock.Setup(c => c.GetCoinValue(coin)).Returns(0.10m);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            _service.InsertCoin(coin);
            _service.ShowDisplay();

            Assert.That(sw.ToString(), Does.Contain("0.10"));
        }

        [Test]
        public void Insert_Invalid_Coin_Goes_To_CoinReturn()
        {
            var coin = new Coins { Type = CoinType.Penny };
            _coinRepoMock.Setup(c => c.GetCoinValue(coin)).Returns((decimal?)null);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            _service.InsertCoin(coin);
            _service.ShowCoinReturn();

            Assert.That(sw.ToString(), Does.Contain("0.01"));
        }

        [Test]
        public void SelectProduct_WithSufficientAmount_DispensesProduct()
        {
            var coin = new Coins{ Type = CoinType.Quarter };
            _coinRepoMock.Setup(c => c.GetCoinValue(It.IsAny<Coins>())).Returns(0.25m);
            _service.InsertCoin(coin);
            _service.InsertCoin(coin);
            _service.InsertCoin(coin);

            var product = new ProductsItemType() { Name = "Candy", Price = 0.65m };
            _productRepoMock.Setup(p => p.GetProduct("Candy")).Returns(product);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            _service.SelectProduct("Candy");

            Assert.That(sw.ToString(), Does.Contain("Dispensing Candy"));

            _service.ShowDisplay();
            Assert.That(sw.ToString(), Does.Contain("THANK YOU"));
        }

        [Test]
        public void SelectProduct_WithInsufficientAmount_ShowsPrice()
        {
            var coin = new Coins{ Type = CoinType.Nickel };
            _coinRepoMock.Setup(c => c.GetCoinValue(coin)).Returns(0.05m);
            _service.InsertCoin(coin);

            var product = new ProductsItemType() { Name = "Cola", Price = 1.00m };
            _productRepoMock.Setup(p => p.GetProduct("Cola")).Returns(product);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            _service.SelectProduct("Cola");
            _service.ShowDisplay();

            Assert.That(sw.ToString(), Does.Contain("PRICE $1.00"));
        }

        [Test]
        public void Select_Invalid_Product_Shows_Error()
        {
            _productRepoMock.Setup(p => p.GetProduct("InvalidProduct")).Returns((ProductsItemType)null);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            _service.SelectProduct("InvalidProduct");

            Assert.That(sw.ToString(), Does.Contain("INVALID PRODUCT"));
        }
    }
}

namespace VendingmachineTestCodeCoverage
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}