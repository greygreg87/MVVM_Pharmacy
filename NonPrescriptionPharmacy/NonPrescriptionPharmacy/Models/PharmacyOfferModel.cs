using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonPrescriptionPharmacy.Models
{
    public class PharmacyOfferModel
    {
        #region Constructors
        public PharmacyOfferModel(string s, ObservableCollection<MedicamentModel> mm)
        {
            MedicamentList = mm;
            BaseReader(s);
        }
        #endregion

        #region Fields & Properties
        private ObservableCollection<MedicamentModel> medicamentList;
        public ObservableCollection<MedicamentModel> MedicamentList
        {
            set { medicamentList = value; }
            get { return medicamentList; }
        }
        #endregion

        #region Methods
        public void BaseReader(string s)
        {
            SQLiteConnection DatabaseConnection = new SQLiteConnection("Data Source=PharmacyDatabase.db;Version=3");
            DatabaseConnection.Open();
            string Select = "SELECT * FROM " + s;
            SQLiteCommand DatabaseCommand = new SQLiteCommand(Select, DatabaseConnection);
            SQLiteDataReader DatabaseReader = DatabaseCommand.ExecuteReader();
            while (DatabaseReader.Read())
            {
                medicamentList.Add(new MedicamentModel((string)DatabaseReader["Name"], (double)DatabaseReader["Price"]));
            };

            DatabaseConnection.Close();
        }
        #endregion   
    }
}
