using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonPrescriptionPharmacy.Models
{
    public class MedicamentModel
    {
        #region Constructors
        public MedicamentModel(string n, double p)
        {
            Name = n;
            Price = p;
        }
        #endregion

        #region Fields
        private string name;
        private double price;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion
    }


}
