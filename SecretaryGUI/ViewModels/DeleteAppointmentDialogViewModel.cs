using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    public class DeleteAppointmentDialogViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        private String _text;
        private String _yes;
        private String _no;

        public DeleteAppointmentDialogViewModel (CultureInfo language)
        {
            Language = language;
        }

        public string Text
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("deleteAppointmentText", Language);
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
