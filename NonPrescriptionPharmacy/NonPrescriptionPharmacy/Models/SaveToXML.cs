using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NonPrescriptionPharmacy.Models
{
    class SaveToXML
    {
        public static void SaveList(string path, ObservableCollection<ChoosenMedicamentModel> list)
        {
            try
            {
                XDocument xml = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("DataZapisania: " + DateTime.Now.ToString(CultureInfo.InvariantCulture)),
                    new XElement("WybraneLeki", from ChoosenMedicamentModel medicament in list select new XElement("Lek",
                        new XElement("Nazwa", medicament.Name),
                        new XElement("CenaJednostkowa", medicament.TotalPrice/medicament.Amount),
                        new XElement("Ilość", medicament.Amount),
                        new XElement("CenaSumaryczna", medicament.TotalPrice)
                    )));
                xml.Save(path);
            }
            catch (Exception exc)
            {
                throw new Exception("Błąd przy zapisie danych do pliku XML", exc);
            }
        }
    }
}
