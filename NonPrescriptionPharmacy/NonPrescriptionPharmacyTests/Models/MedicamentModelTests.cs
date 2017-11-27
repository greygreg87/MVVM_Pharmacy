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
    public class MedicamentModelTests
    {
        [TestMethod]
        public void MedicamentModelTest()
        {
            // Arrange
            string name = "Apap";
            double price = 10.99;

            // Act
            MedicamentModel Drug = new MedicamentModel(name, price);

            // Assert
            Assert.AreEqual(Drug.Name, name, "Błąd we własciwości Name");
            Assert.AreEqual(Drug.Price, price, "Bład we właściwości Price");
        }
    }
}