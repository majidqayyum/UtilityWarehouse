using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityWarehouse;

namespace UtilityWarehouse.Test
{
    [TestClass]
    public class TerminalTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void SetPricing_NoProductName_ThrowsException()
        {
            // Arrange
            var Terminal = new Terminal();
            
            // Act
            Terminal.SetPricing("", 3);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void SetPricing_NoPriceName_ThrowsException()
        {
            // Arrange
            var Terminal = new Terminal();

            // Act
            Terminal.SetPricing("A", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void SetPricing_DuplicateProduct_ThrowsException()
        {
            // Arrange
            var Terminal = new Terminal();

            // Act
            Terminal.SetPricing("A", 3);
            Terminal.SetPricing("A", 3);
        }

        [TestMethod]
        public void SetPricing_MultipleProducts_CorrectCount()
        {
            // Arrange
            var Terminal = new Terminal();
            Terminal.SetPricing("A", 3);
            Terminal.SetPricing("B", 4);
            Terminal.SetPricing("C", 6);
            
            // Act
            var ProductCount = Terminal._products.Count;

            // Assert
            Assert.AreEqual(3, ProductCount, "SetPricing did not add the products correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Scan_BlankProduct_ThrowsException()
        {
            // Arrange
            var Terminal = new Terminal();
            Terminal.SetPricing("A", 3);

            // Act
            Terminal.Scan("");
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Scan_ProductNotPricedOnTerminal_ThrowsException()
        {
            // Arrange
            var Terminal = new Terminal();
            Terminal.SetPricing("A", 3);

            // Act
            Terminal.Scan("B");
        }

        [TestMethod]
        public void Scan_Increments_CorrectQuantity()
        {
            // Arrange
            var Terminal = new Terminal();
            Terminal.SetPricing("A", 3);

            // Act
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");

            // Assert
            var Result = Terminal._products.Find(x => x.ProductCode == "A").Quantity;

            Assert.AreEqual(5, Result,"Scan does not increment the quantity correctly.");                
        }

        [TestMethod]
        public void Total_ValidScan_CorrectTotal()
        {
            // Arrange
            var Terminal = new Terminal();
            Terminal.SetPricing("A", 3);

            // Act
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");

            // Assert
            var Result = Terminal.Total();

            Assert.AreEqual(15, Result, "Total incorrect correctly.");
        }

        [TestMethod]
        public void NextCustomer_ScannedItems_ClearsQuantities()
        {
            // Arrange
            var Terminal = new Terminal();
            Terminal.SetPricing("A", 3);

            // Act
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");
            Terminal.Scan("A");

            var ResultBefore = Terminal._products.Find(x => x.ProductCode == "A").Quantity;
            Terminal.NextCustomer();
            var ResultAfter = Terminal._products.Find(x => x.ProductCode == "A").Quantity;

            Assert.AreEqual(5, ResultBefore, "Incorrect Quantity Count");
            Assert.AreEqual(0, ResultAfter, "Incorrect Quantity Count");
        }        
    }
}
