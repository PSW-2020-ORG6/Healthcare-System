using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using System;
using System.Globalization;
using System.Resources;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class PersonalizationViewModel : ViewModelBase
    {
        public static String StyleName;
        public static CultureInfo Language;
        private string _languageLabelText;
        private string _themeLabelText;

        public PersonalizationViewModel(CultureInfo language)
        {
            Language = language;
        }

        public ICommand ChangeStyleCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchStyleMessage>(new SwitchStyleMessage { StyleName = StyleName });
                });
            }
        }

        public ICommand ChangeLanguageCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<ChangeLanguageMessage>(new ChangeLanguageMessage { Language = Language });
                    RaisePropertyChanged("ThemeLabelText");
                    RaisePropertyChanged("LanguageLabelText");
                });
            }
        }

        public string LanguageLabelText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("langLabel", Language);
            }
            set
            {
                _languageLabelText = value;
                RaisePropertyChanged("LanguageLabelText");
            }
        }
        public string ThemeLabelText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("themeLabel", Language);
            }
            set
            {
                _themeLabelText = value;
                RaisePropertyChanged("ThemeLabelText");
            }
        }
    }
}
