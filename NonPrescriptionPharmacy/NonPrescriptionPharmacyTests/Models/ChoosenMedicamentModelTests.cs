using Microsoft.VisualStudio.TestTools.UnitTesting;
using NonPrescriptionPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonPrescriptionPharmacy.Models.Tests
{
    [TestClass]
    public class ChoosenMedicamentModelTests
    {
        [TestMethod]
        public void ChoosenMedicamentModelTest()
        {
            // Arrange
            string name = "Paracetamol 500mg";
            double price = 15.99;
            int amount = 4;

            // Act
            ChoosenMedicamentModel Drug = new ChoosenMedicamentModel(name, amount, price);

            // Assert
            Assert.AreEqual(Drug.Name, name, "Błąd we własciwości Name");
            Assert.AreEqual(Drug.Amount, amount, "Błąd we własciwości Amount");
            Assert.AreEqual(Drug.TotalPrice, price*amount, "Bład we właściwości TotalPrice");
        }
    }
}