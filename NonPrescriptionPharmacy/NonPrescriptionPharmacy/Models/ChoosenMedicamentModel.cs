using NonPrescriptionPharmacy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonPrescriptionPharmacy.Models
{
    public class ChoosenMedicamentModel : BindableBase
    {
        #region Constructors
        public ChoosenMedicamentModel(string n, int a, double t)
        {
            Name = n;
            Amount = a;
            TotalPrice = t * a;
        }
        #endregion

        #region Fields
        private string name;
        private int amount;
        private double totalPrice;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        #endregion
    }
}
