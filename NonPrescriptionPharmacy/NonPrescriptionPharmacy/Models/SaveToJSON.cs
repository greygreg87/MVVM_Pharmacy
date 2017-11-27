using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonPrescriptionPharmacy.Models
{
    class SaveToJSON
    {
        public static void SaveList(string path, ObservableCollection<ChoosenMedicamentModel> list)
        {
            try
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, list);
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Błąd przy zapisie danych do pliku JSON", exc);
            }
        }
    }
}
