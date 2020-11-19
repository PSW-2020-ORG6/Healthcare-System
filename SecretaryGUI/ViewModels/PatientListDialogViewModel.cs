using Backend.Controller.SecretaryControllers;
using Model.Accounts;
using GalaSoft.MvvmLight;
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

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class PatientListDialogViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        private String _nameText;
        private String _surnameText;
        private String _idText;
        private String _searchText;
        private String _chooseText;
        private String _declineText;

        ObservableListConverter<Patient> observableListConverter = new ObservableListConverter<Patient>();
        private SecretaryHospitalController secretaryHospitalController = new SecretaryHospitalController();

        public ObservableCollection<Patient> Patients
        {
            get;
            set;
        }

        public PatientListDialogViewModel(CultureInfo language)
        {
            Language = language;
            Patients = new ObservableCollection<Patient>();

            Patients = observableListConverter.ToObservable(secretaryHospitalController.GetAllPatients());

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

        public string DeclineText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("declineButtonText", Language);
            }
            set
            {
                _declineText = value;
                RaisePropertyChanged("DeclineText");
            }
        }

        public string ChooseText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("chooseText", Language);
            }
            set
            {
                _chooseText = value;
                RaisePropertyChanged("ChooseText");
            }
        }
    }
}
