using Backend.Controller.SecretaryControllers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using HCI_SIMS_PROJEKAT.Util;
using Model.Accounts;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Resources;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class PhysitianListViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        private String _searchText;
        private String _nameText;
        private String _surnameText;
        private String _specializationText;
        private String _phoneText;

        private ObservableCollection<Physitian> temp;
        private ObservableCollection<Physitian> allPhysitian;
        private ObservableCollection<Physitian> physitians;

        ObservableListConverter<Physitian> observableListConverter = new ObservableListConverter<Physitian>();

        public ObservableCollection<Physitian> SearchPhysitians
        {
            get;
            set;
        }


        public PhysitianListViewModel(CultureInfo language)
        {
            Language = language;
            Physitians = new ObservableCollection<Physitian>();
            SecretaryHospitalController secretaryHospitalController = new SecretaryHospitalController();

            temp = observableListConverter.ToObservable(secretaryHospitalController.GetAllPhysitians());
            temp.RemoveAt(0);
            Physitians = temp;
            allPhysitian = Physitians;

            SearchPhysitians = new ObservableCollection<Physitian>();

            Messenger.Default.Register<SearchPhysitianMessage>(this, (searchPhysitianMessage) =>
            {
                updateTable(searchPhysitianMessage.Pretraga);
            });
        }

        private void updateTable(string pretraga)
        {
            Console.WriteLine(pretraga);

            SearchPhysitians.Clear();

            foreach (Physitian p in allPhysitian)
            {
                if (p.Surname.ToLower().Contains(pretraga.ToLower()))
                {
                    if (!SearchPhysitians.Contains(p))
                        SearchPhysitians.Add(p);
                }

                if (p.AllSpecializations.ToLower().Contains(pretraga.ToLower()))
                {
                    if (!SearchPhysitians.Contains(p))
                        SearchPhysitians.Add(p);
                }

                if (p.Name.ToLower().Contains(pretraga.ToLower()))
                {
                    if (!SearchPhysitians.Contains(p))
                        SearchPhysitians.Add(p);
                }
            }

            Physitians = SearchPhysitians;
        }

        public ObservableCollection<Physitian> Physitians
        {
            get
            {
                return physitians;
            }
            set
            {
                physitians = value;
                RaisePropertyChanged("Physitians");
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

        public string SpecializationText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("specializationText", Language);
            }
            set
            {
                _specializationText = value;
                RaisePropertyChanged("SpecializationText");
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
    }
}
