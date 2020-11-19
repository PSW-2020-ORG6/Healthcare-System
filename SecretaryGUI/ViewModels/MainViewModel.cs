using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        private String _accountText;
        private String _nameText;
        private String _surnameText;
        private String _cityText;
        private String _positionText;

        public MainViewModel(CultureInfo language)
        {
            Language = language;
        }

        public string AccountText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("accountText", Language);
            }
            set
            {
                _accountText = value;
                RaisePropertyChanged("AccountText");
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

        public string PositionText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("positionText", Language);
            }
            set
            {
                _positionText = value;
                RaisePropertyChanged("PositionText");
            }
        }
    }
}
