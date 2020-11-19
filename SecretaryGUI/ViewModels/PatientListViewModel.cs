using Backend.Controller.SecretaryControllers;
using Model.Accounts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using HCI_SIMS_PROJEKAT.Util;
using HCI_SIMS_PROJEKAT.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Backend.Controller;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class PatientListViewModel : ViewModelBase
    {

        public static CultureInfo Language;
        private String styleName;
        private String _addAppointmentText;
        private String _searchText;
        private String _nameText;
        private String _surnameText;
        private String _idText;
        private String _phoneText;
        private String _deleteText;
        private String _dateOfBirthText;
        private ObservableCollection<Patient> patients;
        private ObservableCollection<Patient> allPatients;
        private PatientRegistrationController patientRegistrationController;
        private SecretaryHospitalController secretaryHospitalController;

        private ObservableListConverter<Patient> observableListConverter = new ObservableListConverter<Patient>();

        public ObservableCollection<Patient> Patients
        {
            get
            {
                return patients;
            }
            set
            {
                patients = value;
                RaisePropertyChanged("Patients");
            }
        }

        public ObservableCollection<Patient> SearchPatients
        {
            get;
            set;
        }

        public PatientListViewModel(CultureInfo language, String style)
        {
            Language = language;
            styleName = style;
            secretaryHospitalController = new SecretaryHospitalController();
            patientRegistrationController = new PatientRegistrationController();

            Patients = new ObservableCollection<Patient>();
            Patients = observableListConverter.ToObservable(secretaryHospitalController.GetAllPatients());

            allPatients = Patients;

            SearchPatients = new ObservableCollection<Patient>();

            Messenger.Default.Register<DeletePatientMessage>(this, (deletePatientMessage) =>
            {
                if(deletePatientMessage.patient == null)
                {
                    return;
                }
                deletePatient(deletePatientMessage.patient);
            });

            Messenger.Default.Register<AddAppointmentFromPatientViewModelMessage>(this, (addAppointmentFromPatientViewModelMessage) =>
            {
                Messenger.Default.Send<AddAppointmentPatientMessage>(new AddAppointmentPatientMessage { patient = addAppointmentFromPatientViewModelMessage.patient });
            });

            Messenger.Default.Register<SearchPatientMessage>(this, (searchPatientMessage) =>
            {
                updateTable(searchPatientMessage.Pretraga);
            });
        }

        private void deletePatient(Patient patient)
        {
            patientRegistrationController.DeletePatientAccount(patient);
            Patients = observableListConverter.ToObservable(secretaryHospitalController.GetAllPatients());
        }

        private void updateTable(String searchText)
        {
            Console.WriteLine(searchText);

            SearchPatients.Clear();

            foreach (Patient p in allPatients)
            {
                if (p.Surname.ToLower().Contains(searchText.ToLower()))
                {
                    if(!SearchPatients.Contains(p))
                        SearchPatients.Add(p);
                }

                if (p.Id.ToLower().Contains(searchText.ToLower()))
                {
                    if(!SearchPatients.Contains(p))
                        SearchPatients.Add(p);
                }

                if (p.Name.ToLower().Contains(searchText.ToLower()))
                {
                    if (!SearchPatients.Contains(p))
                        SearchPatients.Add(p);
                }
            }

            Patients = SearchPatients;
        }

        public string AddAppointmentText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("appointmentAddButton", Language);
            }
            set
            {
                _addAppointmentText = value;
                RaisePropertyChanged("AddAppointmentText");
            }
        }

        public string SearchText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("searchText", Language);
            }
            set
            {
                _searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        public string NameText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("nameText", Language);
            }
            set
            {
                _nameText = value;
                RaisePropertyChanged("NameText");
            }
        }

        public string SurnameText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("surnameText", Language);
            }
            set
            {
                _surnameText = value;
                RaisePropertyChanged("SurnameText");
            }
        }

        public string PhoneText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("phoneText", Language);
            }
            set
            {
                _phoneText = value;
                RaisePropertyChanged("PhoneText");
            }
        }

        public string IDText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("idText", Language);
            }
            set
            {
                _idText = value;
                RaisePropertyChanged("IDText");
            }
        }

        public string DeleteText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("deleteButtonText", Language);
            }
            set
            {
                _deleteText = value;
                RaisePropertyChanged("DeleteText");
            }
        }

        public string DateOfBirthText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("dateOfBirthText", Language);
            }
            set
            {
                _dateOfBirthText = value;
                RaisePropertyChanged("DateOfBirthText");
            }
        }


        public ICommand ChangeToAppointmentViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "AppointmentViewFromPatient" });
                });
            }
        }

        public ICommand InstantiateDeletePatientDialog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    showDeletePatientDialog();
                });
            }
        }

        private void showDeletePatientDialog()
        {
            DeletePatientDialog deletePatientDialog = new DeletePatientDialog(styleName);
            deletePatientDialog.DataContext = new DeletePatientDialogViewModel(Language);
            deletePatientDialog.Owner = Application.Current.MainWindow;
            deletePatientDialog.ShowDialog();
        }
    }
}
