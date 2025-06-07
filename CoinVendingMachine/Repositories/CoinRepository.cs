using CoinVendingMachine.Models;
using CoinVendingMachine.Repositories.Interfaces;
using CoinVendingMachine.Constants;

namespace CoinVendingMachine.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        /// <summary>
        /// To get the coin value.
        /// </summary>
        /// <param name="coin">coin type</param>
        /// <returns>Return the coin value</returns>
        public decimal? GetCoinValue(Coins coin)
        {
            if (Constant.CoinValues.TryGetValue(coin.Type, out var value))
                return value;
            return null; // Invalid coin
        }
    }
}
