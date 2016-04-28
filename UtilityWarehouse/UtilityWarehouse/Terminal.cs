using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityWarehouse
{
    /// <summary>
    /// This is the point of sale 
    /// </summary>
    class Terminal : ITerminal
    {
        internal List<Product> _products = new List<Product>();

        /// <summary>
        /// Set up the products at the store including unit and bulk price and quantities.
        /// </summary>
        /// <param name="product">Product name</param>
        /// <param name="price">Unit price</param>
        /// <param name="bulkPrice">Bulk price</param>
        /// <param name="bulkQuantity">Bulk quantity</param>
        public void SetPricing(string product, decimal price, decimal bulkPrice = 0, int bulkQuantity = 0)
        {
            // Check for invalid arguments
            if (string.IsNullOrEmpty(product.Trim()) || price == 0)
            {
                throw new ArgumentNullException("Invalid product, price ");
            }

            Product result = _products.Find(x => x.ProductCode == product);

            if (result == null)
            {
                _products.Add(new Product(product, price,bulkPrice,bulkQuantity));
            }
            else
            {
                // Product already exists, invalid operation.
                throw new InvalidOperationException("Product already exists on the Terminal");
            }
        }

        /// <summary>
        /// Increment product count if it exists.
        /// </summary>
        /// <param name="product">Product code</param>
        public void Scan(string product)
        {
            if (string.IsNullOrEmpty(product.Trim()))
            {
                throw new ArgumentNullException("Invalid product");
            }

            // Check if product exists in store
            Product result = _products.Find(x => x.ProductCode == product.Trim());

            if (result == null)
            {
                // Product does not exists, invalid operation.
                throw new InvalidOperationException("Product does not exists on the Terminal");
            }

            // Increse Quantity
            result.Quantity++;
        }

        /// <summary>
        /// Calculates the total of the shop.
        /// </summary>
        /// <returns>Total of all items.</returns>
        public decimal Total()
        {
            decimal Total = 0M;
            foreach (var product in _products)
            {
                Total += product.Total();
            }
            return Total;
        }

        // This clears the terminal for the next shop.
        public void NextCustomer()
        {
            foreach (var product in this._products)
            {
                product.Quantity = 0;
            }
        }
    }
}
