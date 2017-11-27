using NonPrescriptionPharmacy.Models;
using NonPrescriptionPharmacy.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NonPrescriptionPharmacy.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        public ObservableCollection<ChoosenMedicamentModel> SummaryList;
        public double SummaryCost = 0;
        SummaryViewModel viewModel;
        Window window;

        public SummaryWindow(ObservableCollection<ChoosenMedicamentModel> list, double cost)
        {
            SummaryList = list;
            SummaryCost = cost;
            window = this;
            viewModel = new SummaryViewModel(SummaryList, SummaryCost, window);
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
