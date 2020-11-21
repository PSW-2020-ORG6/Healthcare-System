
using Backend.Controller.PhysitianControllers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.util;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HealthClinic.ViewModel
{
    public class AddMedicineDosageViewModel : ViewModelBase
    {
        private ObservableCollection<Medicine> medicine;
        private Medicine selectedMedicine;
        private PhysitianMedicineController physitianMedicineController;
        private String notes;
        private double amount;
        private MedicineDosage oldMedicineDosage;
        public ObservableCollection<Medicine> Medicine { get => medicine; set => medicine = value; }
        public int SelectedMedicine
        {
            get
            {
                for (int i = 0; i <= medicine.Count; i++)
                {
                    if (selectedMedicine.Equals(medicine[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                selectedMedicine = medicine[value];
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                RaisePropertyChanged("Amount");
            }
        }

        public AddMedicineDosageViewModel()
        {
            initialiize();
            this.amount = 0.25;
        }

        public AddMedicineDosageViewModel(MedicineDosage oldMedicineDosage)
        {
            initialiize();
            this.oldMedicineDosage = oldMedicineDosage;
            this.selectedMedicine = oldMedicineDosage.Medicine;
            this.Notes = oldMedicineDosage.Note;
            this.Amount = oldMedicineDosage.Amount;
        }

        private void initialiize()
        {
            Physitian physitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianMedicineController = new PhysitianMedicineController();
            ObservableListConverter<Medicine> converter = new ObservableListConverter<Medicine>();
            Medicine = converter.ToObservable(physitianMedicineController.getAllApproved());
            selectedMedicine = Medicine[0];
            RaisePropertyChanged("SelectedMedicine");
        }

        public ICommand AddMedicineDosageCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if(oldMedicineDosage != null)
                    {
                        Messenger.Default.Send<DeleteMedicineDosageMessage>(new DeleteMedicineDosageMessage { medicineDosage = oldMedicineDosage });
                    }
                    MedicineDosage medicineDosage = new MedicineDosage(amount, notes, selectedMedicine);
                    Messenger.Default.Send<AddMedicineDosageMessage>(new AddMedicineDosageMessage { medicineDosage = medicineDosage });
                });
            }
        }
    }
}
