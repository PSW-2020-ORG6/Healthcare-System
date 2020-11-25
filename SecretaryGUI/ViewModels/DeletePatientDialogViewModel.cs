using GalaSoft.MvvmLight;
using System;
using System.Globalization;
using System.Resources;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class DeletePatientDialogViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        private String _text;
        private String _yes;
        private String _no;

        public DeletePatientDialogViewModel(CultureInfo language)
        {
            Language = language;
        }

        public string Text
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("deletePatientText", Language);
            }
            set
            {
                _text = value;
                RaisePropertyChanged("Text");
            }
        }

        public string Yes
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("yes", Language);
            }
            set
            {
                _yes = value;
                RaisePropertyChanged("Yes");
            }
        }

        public string No
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("no", Language);
            }
            set
            {
                _no = value;
                RaisePropertyChanged("No");
            }
        }
    }
}
