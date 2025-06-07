using CoinVendingMachine.Constants;
using CoinVendingMachine.Models;
using CoinVendingMachine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinVendingMachine.Repositories
{
    public class ProductItemTypeRepository : IProductItemTypeRepository
    {
        /// <summary>
        /// Get the Product based on name.
        /// </summary>
        /// <param name="name">product name</param>
        /// <returns>Return the Product.</returns>
        public ProductsItemType GetProduct(string name)
        {
            Constant.Products.TryGetValue(name, out var product);
            return product;
        }

        /// <summary>
        /// Get all the products.
        /// </summary>
        /// <returns>Return all the product.</returns>
        public IEnumerable<ProductsItemType> GetAllProducts() => Constant.Products.Values;
    }
}

