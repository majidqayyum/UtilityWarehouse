using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityWarehouse
{
    /// <summary>
    /// Point of Sale - checkout interface. Set product prices, scan and get totals for shop.
    /// </summary>
    interface ITerminal
    {
        // Sets prices for a product.
        void SetPricing(string product, decimal price, decimal bulkPrice, int bulkQuantity);
        // Scans a product and increments count.
        void Scan(string product);
        // Returns total value of shop.
        decimal Total();
        // Clears the terminal for the next shop.
        void NextCustomer();
    }
}
