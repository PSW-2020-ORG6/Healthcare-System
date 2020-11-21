using Model.Accounts;
using Model.Hospital;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.FrontendAdapters;
using HealthClinic.Message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using health_clinic_class_diagram.Backend.Controller.PhysitianControllers;
using Backend.Controller.PhysitianControllers;

namespace HealthClinic.ViewModel
{
    class MedicineViewModel : ViewModelBase
    {
        private PhysitianMedicineController physitianMedicineController;
        private PhysitianHospitalController physitianHospitalController;

        private ObservableCollection<MedicineAdapter> allMedicine;
        private ObservableCollection<MedicineAdapter> medicine;
        private MedicineAdapter selectedMedicine;

        private String searchQuery;
        private List<MedicineManufacturer> manufacturers;
        private MedicineManufacturer selectedManufacturer;
        private int selectedApproval;

        public bool IsMedicineSelected
        {
            get
            {
                return selectedMedicine != null;
            }
        }

        public MedicineAdapter SelectedMedicine
        {
            get
            {
                return selectedMedicine;
            }
            set
            {
                selectedMedicine = value;
                RaisePropertyChanged("SelectedMedicine");
                RaisePropertyChanged("IsMedicineSelected");
            }
        }
        public MedicineViewModel()
        {
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianMedicineController = new PhysitianMedicineController();
            physitianHospitalController = new PhysitianHospitalController();
            allMedicine = new ObservableCollection<MedicineAdapter>();

            foreach(Medicine m in physitianMedicineController.getAllApproved())
            {
                allMedicine.Add(new MedicineAdapter(m, true));
            }

            foreach (Medicine m in physitianMedicineController.getAllFromWaitingList())
            {
                allMedicine.Add(new MedicineAdapter(m, false));
            }

            Medicine = allMedicine;

            manufacturers = new List<MedicineManufacturer>();
            manufacturers.Add(new MedicineManufacturer("Svi proizvođači"));
            manufacturers.AddRange(physitianMedicineController.GetMedicineManufacturers());
            searchQuery = "";
            SelectedManufacturer = 0;
            SelectedApproval = 0;
        }

        public ICommand ChangeToHomeViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "default" });
                });
            }
        }

        public ICommand ShowMedicineDetailCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if(selectedMedicine.IsApproved)
                    {
                        Messenger.Default.Send<OpenMedicineDetailViewMessage>(new OpenMedicineDetailViewMessage { Medicine = SelectedMedicine.Medicine });
                    } else
                    {
                        Messenger.Default.Send<OpenMedicineApprovalViewMessage>(new OpenMedicineApprovalViewMessage { Medicine = SelectedMedicine.Medicine });
                    }
                    
                });
            }
        }

        public List<MedicineManufacturer> Manufacturers
        {
            get
            {
                return manufacturers;
            }
        }
        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }
            set
            {
                searchQuery = value;
                Medicine = searchMedicine();
            }
        }

        private ObservableCollection<MedicineAdapter> searchMedicine()
        {
            ObservableCollection<MedicineAdapter> searchResults = new ObservableCollection<MedicineAdapter>();
            searchQuery = searchQuery.ToLower();

            foreach(MedicineAdapter m in allMedicine)
            {
                String copyrightName = m.Medicine.CopyrightName.ToLower();
                String genericName = m.Medicine.GenericName.ToLower();
                String medicineType = m.Medicine.MedicineType.Type.ToLower();

                if (selectedApproval == 1 && !m.IsApproved)
                {
                    continue;
                }
                if(selectedApproval == 2 && m.IsApproved)
                {
                    continue;
                }
                if(SelectedManufacturer != 0 && !selectedManufacturer.Equals(m.Medicine.MedicineManufacturer))
                {
                    continue;
                }
                if(copyrightName.Contains(searchQuery) || genericName.Contains(searchQuery) || medicineType.Contains(searchQuery))
                {
                    searchResults.Add(m);
                }
            }

            return searchResults;
        }

        public int SelectedManufacturer
        {
            get
            {
                for(int i=0; i < Manufacturers.Count; i++)
                {
                    if(selectedManufacturer.Equals(Manufacturers[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                selectedManufacturer = Manufacturers[value];
                Medicine = searchMedicine();
                RaisePropertyChanged("SelectedManufacturer");
            }
        }
        public int SelectedApproval
        {
            get
            {
                return selectedApproval;
            }
            set
            {
                selectedApproval = value;
                Medicine = searchMedicine();
                RaisePropertyChanged("SelectedApproval");
            }
        }
        public ObservableCollection<MedicineAdapter> Medicine
        {
            get
            {
                return medicine;
            }
            set
            {
                medicine = value;
                RaisePropertyChanged("Medicine");
            }
        }
    }
}
