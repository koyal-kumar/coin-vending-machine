using CoinVendingMachine.Models;

namespace CoinVendingMachine.Repositories.Interfaces
{
    public interface ICoinRepository
    {
        /// <summary>
        /// To get the coin value.
        /// </summary>
        /// <param name="coin">coin type</param>
        /// <returns>Return the coin value</returns>
        decimal? GetCoinValue(Coins coin);
    }
}
