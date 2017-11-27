using NonPrescriptionPharmacy.Helpers;
using NonPrescriptionPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NonPrescriptionPharmacy.ViewModels
{
    class SummaryViewModel : BindableBase
    {
        #region Constructors
        public SummaryViewModel(ObservableCollection<ChoosenMedicamentModel> list, double cost, Window window)
        {
            SummaryMedicament = list;
            SummaryCost = cost;
            SummaryWindow = window;
            CancelCommand = new Command(Cancel, CanCancel);
            PayCommand = new Command(Pay, CanPay);
        }
        #endregion

        #region Fields    
        private ObservableCollection<ChoosenMedicamentModel> summaryMedicament;
        private double summaryCost = 100;
        private Window SummaryWindow;
        private const string filePathJson = "MedicamentOrder.json";
        private const string filePathXml = "MedicamentOrder.xml";
        #endregion

        #region Properties    
        public double SummaryCost
        {
            get { return summaryCost; }
            set
            {
                summaryCost = value;
                OnPropertyChanged("SummaryCost");
            }
        }

        public ObservableCollection<ChoosenMedicamentModel> SummaryMedicament
        {
            get { return summaryMedicament; }
            set
            {
                summaryMedicament = value;
                OnPropertyChanged("SummaryMedicament");
            }
        }
        #endregion

        #region Commads
        public ICommand CancelCommand{ get; set; }
        private void Cancel(object obj)
        {
            SummaryWindow.Close();
        }
        private bool CanCancel(object obj)
        {
            return true;
        }

        public ICommand PayCommand { get; set; }
        private void Pay(object obj)
        {
            SaveToJSON.SaveList(filePathJson, SummaryMedicament);
            SaveToXML.SaveList(filePathXml, SummaryMedicament);
            MessageBox.Show("Twoje zamówienie zostało wysłane. Dziękujemy za skorzystanie z serwisu AptekaBezRecepty");
            Environment.Exit(1);
        }
        private bool CanPay(object obj)
        {
            return true;
        }
        #endregion
    }
}
