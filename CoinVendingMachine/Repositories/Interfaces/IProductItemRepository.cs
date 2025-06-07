using CoinVendingMachine.Models;

namespace CoinVendingMachine.Repositories.Interfaces
{
    public interface IProductItemTypeRepository
    {
        /// <summary>
        /// Get the Product based on name.
        /// </summary>
        /// <param name="name">product name</param>
        /// <returns>Return the Product.</returns>
        ProductsItemType GetProduct(string name);

        /// <summary>
        /// Get all the products.
        /// </summary>
        /// <returns>Return all the product.</returns>
        IEnumerable<ProductsItemType> GetAllProducts();
    }
}
