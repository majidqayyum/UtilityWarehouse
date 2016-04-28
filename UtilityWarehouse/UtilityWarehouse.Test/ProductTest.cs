using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityWarehouse;

namespace UtilityWarehouse.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Total_NoBulkPrice_CorrectTotal()
        {
            // Arrange
            var Product = new Product("A",35);
            Product.Quantity = 2;

            // Act
            var Result = Product.Total();

            // Assert
            Assert.AreEqual(70, Result, "The total is not correct when no bulk price specified for a product");
        }

        [TestMethod]
        public void Total_BulkPriceBelowBulkQuantity_CorrectTotal()
        {
            // Arrange
            var Product = new Product("A", 35,20,4);
            Product.Quantity = 2;

            // Act
            var Result = Product.Total();

            // Assert
            Assert.AreEqual(70, Result, "Incorrect total when bulk price specified but the quantity is less than pack quantity");
        }

        [TestMethod]
        public void Total_BulkPriceExactBulkQuantity_CorrectTotal()
        {
            // Arrange
            var Product = new Product("A", 35, 85, 4);
            Product.Quantity = 4; // Exact bulk quantity - with no single items

            // Act
            var Result = Product.Total();

            // Assert
            Assert.AreEqual(85, Result, "Incorrect total when bulk price specified and the quantity is exactly the pack quantity");
        }

        [TestMethod]
        public void Total_BulkPriceOneBulkQuantityOneSingle_CorrectTotal()
        {
            // Arrange
            var Product = new Product("A", 35, 85, 4);
            Product.Quantity = 5; // 1 bulk quantity - with 1 single product

            // Act
            var Result = Product.Total();

            // Assert
            Assert.AreEqual(120, Result, "Incorrect total when bulk price specified and the quantity qualifies with 1 bulk pack and 1 single item");
        }


    }
}
