using NonPrescriptionPharmacy.Helpers;
using NonPrescriptionPharmacy.Models;
using NonPrescriptionPharmacy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NonPrescriptionPharmacy.ViewModels
{
    public class MainViewModel : BindableBase
    {      
        #region Constructors  
        public MainViewModel()
        {
            AddMedicamentCommand = new Command(AddMedicament, CanAddMedicament);
            RemoveMedicamentCommand = new Command(RemoveMedicament, CanRemoveMedicament);
            SummaryMedicamentCommand = new Command(SummaryMedicament, CanSummaryMedicament);
            LoadListOfMedicament = new Command(LoadList, CanLoadList);
            Amount = 0;
        }
        #endregion

        #region Fields
        private ObservableCollection<MedicamentModel> listOfMedicament;
        private MedicamentModel selectedMedicament;
        private ObservableCollection<ChoosenMedicamentModel> listOfChoosenMedicament = new ObservableCollection<ChoosenMedicamentModel>();
        private ChoosenMedicamentModel selectedMedicamentFromChoosenList;
        private double totalCost = 0;
        private int amount;
        private string typeOfMedicament;
        #endregion

        #region Properties
        public MedicamentModel SelectedMedicament
        {
            get { return selectedMedicament; }
            set
            {
                selectedMedicament = value;
                OnPropertyChanged("SelectedMedicament");
            }
        }

        public ObservableCollection<MedicamentModel> ListOfMedicament
        {
            get { return listOfMedicament; }
            set
            {
                listOfMedicament = value;
                OnPropertyChanged("ListOfMedicament");
            }
        }

        public ObservableCollection<ChoosenMedicamentModel> ListOfChoosenMedicament
        {
            get { return listOfChoosenMedicament; }
            set
            {              
                listOfChoosenMedicament = value;
                OnPropertyChanged("ListOfChoosenMedicament");
            }
        }

        public ChoosenMedicamentModel SelectedMedicamentFromChoosenList
        {
            get { return selectedMedicamentFromChoosenList; }
            set
            {
                selectedMedicamentFromChoosenList = value;
                OnPropertyChanged("SelectedMedicamentFromChoosenList");
            }
        }
      
        public double TotalCost
        {
            get { return totalCost; }
            set
            {
                totalCost = Math.Round(value, 2);
                OnPropertyChanged("TotalCost");
            }
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public string TypeOfMedicament
        {
            get { return typeOfMedicament; }
            set
            {
                typeOfMedicament = value;
                OnPropertyChanged("TypeOfMedicament");
            }
        }

        #endregion

        #region Commands
        public ICommand AddMedicamentCommand { get; set; }
        private void AddMedicament(object obj)
        {
            int previousAmount = 0;

            for (int i = 0; i < ListOfChoosenMedicament.Count; i++)
            {
                if(ListOfChoosenMedicament.ElementAt(i).Name == SelectedMedicament.Name)
                {
                    previousAmount = RemoveOldMedicament(ListOfChoosenMedicament.ElementAt(i));                                      
                }
            }
            CreateNewMedicament(SelectedMedicament, previousAmount);        
        }

        private bool CanAddMedicament(object obj)
        {
            return (SelectedMedicament != null) && (CheckCorrectOfAmount(Amount));
        }

        public ICommand RemoveMedicamentCommand { get; set; }
        private void RemoveMedicament(object obj)
        {
            TotalCost -= SelectedMedicamentFromChoosenList.TotalPrice;
            ListOfChoosenMedicament.Remove(SelectedMedicamentFromChoosenList);
            SelectedMedicamentFromChoosenList = null;
        }

        private bool CanRemoveMedicament(object obj)
        {
            bool b = SelectedMedicamentFromChoosenList != null ? true : false;
            return b;
        }

        public ICommand SummaryMedicamentCommand { get; set; }
        private void SummaryMedicament(object obj)
        {
            SummaryWindow window = new SummaryWindow();
            SummaryViewModel windowVm = new SummaryViewModel(ListOfChoosenMedicament, TotalCost, window);
            window.DataContext = windowVm;
            window.Show();
        }

        private bool CanSummaryMedicament(object obj)
        {
            bool b = TotalCost > 0 ? true : false;
            return b;
        }

        public ICommand LoadListOfMedicament { get; set; }
        private void LoadList (object obj)
        {
            ListOfMedicament = new PharmacyOfferModel(TypeOfMedicament, new ObservableCollection<MedicamentModel>()).MedicamentList;
        }

        private bool CanLoadList(object obj)
        {
            bool b = TypeOfMedicament == null ? false : true;
            return b;
        }
        #endregion

        #region Methods
        public bool CheckCorrectOfAmount (int n)
        {
            if (n > 0) return true;
            else return false;
        }

        public int RemoveOldMedicament(ChoosenMedicamentModel medicament)
        {
            int previousAmount = medicament.Amount;
            TotalCost -= medicament.TotalPrice;
            ListOfChoosenMedicament.Remove(medicament);
            return previousAmount;
        }

        public void CreateNewMedicament(MedicamentModel medicament, int amount)
        {
            ListOfChoosenMedicament.Add(new ChoosenMedicamentModel(medicament.Name, (Amount + amount), medicament.Price));
            TotalCost += medicament.Price * (Amount + amount);
            SelectedMedicament = null;
            Amount = 0;
        }


        #endregion
    }
}
