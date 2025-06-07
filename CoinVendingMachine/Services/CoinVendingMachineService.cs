using CoinVendingMachine.Constants;
using CoinVendingMachine.Models;
using CoinVendingMachine.Repositories.Interfaces;

namespace CoinVendingMachine.Services
{
    public class CoinVendingMachineService
    {
        private string _display = Constant.InsertCoin;
        private decimal _currentAmount = 0.00m;
        private readonly List<decimal> _coinReturn = new();


        private readonly ICoinRepository _coinRepo;
        private readonly IProductItemTypeRepository _productRepo;

        public CoinVendingMachineService(ICoinRepository coinRepo, IProductItemTypeRepository productRepo)
        {
            _coinRepo = coinRepo;
            _productRepo = productRepo;
        }

        /// <summary>
        /// Insert the coin with coin types.
        /// </summary>
        /// <param name="coin">coin type</param>
        public void InsertCoin(Coins coin)
        {
            var value = _coinRepo.GetCoinValue(coin);
            if (value.HasValue)
            {
                _currentAmount += value.Value;
                _display = string.Format(Constant.CurrentAmountDesc, _currentAmount);
            }
            else
            {
                _coinReturn.Add(0.01m); // simulate penny
                _display = _currentAmount > 0 ? string.Format(Constant.CurrentAmountDesc, _currentAmount) : Constant.InsertCoin;
            }
        }

        /// <summary>
        /// Select the product to buy.
        /// </summary>
        /// <param name="name">product name</param>
        public void SelectProduct(string name)
        {
            var product = _productRepo.GetProduct(name);
            if (product == null)
            {
                Console.WriteLine(Constant.InvalidProduct);
                return;
            }

            if (_currentAmount >= product.Price)
            {
                _currentAmount -= product.Price;
                Console.WriteLine(string.Format(Constant.DispensingproductDesc, product.Name));
                _display = Constant.ThankYou;
                Reset();
            }
            else
            {
                _display = string.Format(Constant.ProductPriceDesc, product.Price);
            }
        }

        /// <summary>
        /// Display the current amount or insert coin.
        /// </summary>
        public void ShowDisplay()
        {
            Console.WriteLine(_display);
            if (_display == Constant.ThankYou || _display.StartsWith(Constant.Price))
                _display = _currentAmount > 0 ? string.Format(Constant.CurrentAmountDesc, _currentAmount) : Constant.InsertCoin;
        }

        /// <summary>
        /// Display the coin return.
        /// </summary>
        public void ShowCoinReturn()
        {
            if (_coinReturn.Count == 0)
            {
                Console.WriteLine(Constant.EmptyCoinReturn);
            }
            else
            {
                Console.WriteLine(Constant.CoinReturn);
                foreach (var coin in _coinReturn)
                    Console.WriteLine(string.Format(Constant.CoinReturnDesc, coin));
                _coinReturn.Clear();
            }
        }

        /// <summary>
        /// Reset the current amount to 0.00 $.
        /// </summary>
        private void Reset() => _currentAmount = 0;
    }
}

