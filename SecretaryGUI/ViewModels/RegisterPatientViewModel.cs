using Backend.Controller;
using Backend.Controller.SecretaryControllers;
using Backend.Dto;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using HCI_SIMS_PROJEKAT.Util;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Resources;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    public class RegisterPatientViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        public String _accountTypeText;
        public String _regularAccountText;
        public String _nameText;
        public String _surnameText;
        public String _parentNameText;
        public String _dateOfBirthText;
        public String _idText;
        public String _genderText;
        public String _countryText;
        public String _cityText;
        public String _addressText;
        public String _phoneText;
        public String _fText;
        public String _registrationText;
        public String _declineText;
        public String _guestText;

        private SecretaryHospitalController secretaryHospitalController;
        ObservableListConverter<Country> observableListConverterCountry = new ObservableListConverter<Country>();
        ObservableListConverter<City> observableListConverterCity = new ObservableListConverter<City>();
        ObservableListConverter<String> observableListConverterGender = new ObservableListConverter<String>();
        private ObservableCollection<Country> countries;
        private ObservableCollection<City> cities;
        private ObservableCollection<String> genders;

        private String _password;
        private String _email;
        private String _contact;
        private String _id;
        private String _name;
        private String _surname;
        private String _parentName;
        private String _address;
        private String _gender;
        private DateTime _dateOfBirth;
        private Country _country;
        private City _city;
        private bool _isGuest;

        private PatientRegistrationController patientRegistrationController = new PatientRegistrationController();

        public RegisterPatientViewModel(CultureInfo language)
        {
            Language = language;
            _dateOfBirth = DateTime.Today;
            List<String> genderList = new List<String>();
            genderList.Add("Muski");
            genderList.Add("Zenski");

            secretaryHospitalController = new SecretaryHospitalController();
            countries = observableListConverterCountry.ToObservable(secretaryHospitalController.GetAllCountries());
            foreach (Country c in countries)
            {
                Console.WriteLine(c);
            }
            _country = countries[0];
            cities = observableListConverterCity.ToObservable(_country.Cities);
            _city = cities[0];

            genders = observableListConverterGender.ToObservable(genderList);
            _gender = genders[0];

        }

        public ObservableCollection<City> Cities
        {
            get
            {
                return cities;
            }
            set
            {
                cities = value;
                City = 0;
                RaisePropertyChanged("Cities");
            }
        }

        public int City
        {
            get
            {
                if (_city == null)
                {
                    return 0;
                }
                for (int i = 0; i < Cities.Count; i++)
                {
                    if (_city.Equals(Cities[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                if (value < 0 || value >= cities.Count)
                {
                    value = 0;
                }
                foreach (City c in cities)
                {
                    Console.WriteLine(c);
                }
                _city = cities[value];
                RaisePropertyChanged("City");
            }
        }

        public ObservableCollection<Country> Countries
        {
            get
            {
                return countries;
            }
            set
            {
                countries = value;
                RaisePropertyChanged("Countries");
            }
        }

        public int Country
        {
            get
            {
                if (_country == null)
                {
                    return 0;
                }
                for (int i = 0; i < Countries.Count; i++)
                {
                    if (_country.Equals(Countries[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                _country = countries[value];
                Cities = observableListConverterCity.ToObservable(_country.Cities);
                RaisePropertyChanged("Country");
                RaisePropertyChanged("City");

            }
        }

        public ObservableCollection<String> Genders
        {
            get
            {
                return genders;
            }
            set
            {
                genders = value;
                RaisePropertyChanged("Genders");
            }
        }

        public int Gender
        {
            get
            {
                if (_gender == null)
                {
                    return 0;
                }
                for (int i = 0; i < Genders.Count; i++)
                {
                    if (_gender.Equals(Genders[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                _gender = Genders[value];
                RaisePropertyChanged("Gender");
            }
        }

        public ICommand RegisterPatientCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    RegisterPatient();
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "PatientListView" });
                });
            }
        }

        private void RegisterPatient()
        {
            Address adresa = new Address("");
            if (!(AddressLabel == null))
            {
                adresa = new Address(AddressLabel);
            }

            String parent = "";
            if (!(ParentName == null))
            {
                parent = ParentName;
            }

            String email = "";
            if (!(Email == null))
            {
                email = Email;
            }

            String pass = "";
            if (!(Password == null))
            {
                pass = Password;
            }

            Console.WriteLine(_gender);
            patientRegistrationController.RegisterPatient(new PatientDTO { Name = Name, Surname = Surname, Contact = Contact, DateOfBirth = DateOfBirth, Gender = _gender, Id = Id, ParentName = parent, Email = email, IsGuest = IsGuest, Address = adresa });
        }


        public string RegistrationText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("registrationButtonText", Language);
            }
            set
            {
                _registrationText = value;
                RaisePropertyChanged("RegistrationText");
            }
        }

        public string GuestText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("guestText", Language);
            }
            set
            {
                _guestText = value;
                RaisePropertyChanged("GuestText");
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
                _registrationText = value;
                RaisePropertyChanged("DeclineText");
            }
        }

        public string AccountTypeText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("accountTypeText", Language);
            }
            set
            {
                _accountTypeText = value;
                RaisePropertyChanged("AccountTypeText");
            }
        }

        public string RegularAccountText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("regularAccountText", Language);
            }
            set
            {
                _regularAccountText = value;
                RaisePropertyChanged("RegularAccountText");
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

        public string ParentNameText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("parentNameText", Language);
            }
            set
            {
                _parentNameText = value;
                RaisePropertyChanged("ParentNameText");
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

        public string GenderText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("genderText", Language);
            }
            set
            {
                _genderText = value;
                RaisePropertyChanged("GenderText");
            }
        }

        public string CountryText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("countryText", Language);
            }
            set
            {
                _countryText = value;
                RaisePropertyChanged("CountryText");
            }
        }

        public string CityText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("cityText", Language);
            }
            set
            {
                _cityText = value;
                RaisePropertyChanged("CityText");
            }
        }

        public string AddressText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("addressText", Language);
            }
            set
            {
                _addressText = value;
                RaisePropertyChanged("AddressText");
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

        public string FText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("fText", Language);
            }
            set
            {
                _phoneText = value;
                RaisePropertyChanged("FText");
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                RaisePropertyChanged("Contact");
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                RaisePropertyChanged("Surname");
            }
        }

        public string ParentName
        {
            get
            {
                return _parentName;
            }
            set
            {
                _parentName = value;
                RaisePropertyChanged("ParentName");
            }
        }

        public string AddressLabel
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged("AddressLabel");
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                RaisePropertyChanged("DateOfBirth");
            }
        }

        public bool IsGuest
        {
            get
            {
                return _isGuest;
            }
            set
            {
                _isGuest = value;
                RaisePropertyChanged("IsGuest");
            }
        }
    }
}

