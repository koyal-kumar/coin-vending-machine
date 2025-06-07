using CoinVendingMachine.Enums;
using CoinVendingMachine.Models;

namespace CoinVendingMachine.Constants
{
    public class Constant
    {
        public const string VendingMachine = "Welcome to the Vending Machine (CoinType Version)!";
        public const string MainMenu = "\n--- MENU ---";
        public const string InsertCoinMenu = "1. Insert Coin (Nickel, Dime, Quarter, Penny)";
        public const string SelectProductMenu = "2. Select Product (Cola, Chips, Candy)";
        public const string ShowCoinMenu = "3. Show Coin Return";
        public const string Exit = "4. Exit";
        public const string SelectMenu = "Select: ";
        public const string EnterCoinType = "Enter coin type: ";
        public const string InvalidCoinType = "Invalid coin type.";
        public const string EnterProduct = "Enter product name: ";
        public const string InvalidSelection = "Invalid selection.";
        public const string ThankYouMessage = "Thanks for using the vending machine!";

        public static readonly Dictionary<CoinType, decimal> CoinValues = new()
        {
            { CoinType.Nickel, 0.05m },
            { CoinType.Dime, 0.10m },
            { CoinType.Quarter, 0.25m }
        };

        public static readonly Dictionary<string, ProductsItemType> Products = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Cola", new ProductsItemType() { Name = "Cola", Price = 1.00m } },
            { "Chips", new ProductsItemType() { Name = "Chips", Price = 0.50m } },
            { "Candy", new ProductsItemType() { Name = "Candy", Price = 0.65m } }
        };

        public const string InsertCoin = "INSERT COIN";
        public const string InvalidProduct = "INVALID PRODUCT";
        public const string EmptyCoinReturn = "Coin return is empty.";
        public const string CoinReturn = "Coin return contains:";
        public const string ThankYou = "THANK YOU";
        public const string Price = "PRICE";
        public static readonly string ProductPriceDesc = "PRICE ${0:F2}";
        public static readonly string CurrentAmountDesc = "${0:F2}";
        public static readonly string CoinReturnDesc = "- ${0:F2}";
        public static readonly string DispensingproductDesc = "Dispensing {0}";
    }
}
