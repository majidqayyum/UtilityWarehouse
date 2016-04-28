using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityWarehouse
{

    /// <summary>
    /// Product class containing unit and bulk prices.
    /// </summary>
    class Product
    {
        public Product(string productCode, decimal unitPrice, decimal bulkPrice = 0, int bulkQuantity = 0)
        {
            this.ProductCode = productCode;
            this.UnitPrice = unitPrice;
            this.BulkPrice = bulkPrice;
            this.BulkQuantity = bulkQuantity;
        }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        // Volume price for item.
        public decimal BulkPrice { get; set; }
        // Volume discount quantity.
        public int BulkQuantity { get; set; }
        
        // Returns total of item including volume discount.
        public decimal Total()
        {
            int UnitPriceQuantity = this.Quantity;
            int BulkPriceQuantity = 0;

            if(BulkQuantity > 0 )
            {
                UnitPriceQuantity = Quantity % BulkQuantity;
                BulkPriceQuantity = Quantity / BulkQuantity;
            }

            return UnitPriceQuantity * UnitPrice + BulkPriceQuantity * BulkPrice;
        }

    }
}
