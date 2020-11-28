using GalaSoft.MvvmLight;
using System.Globalization;
using System.Resources;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class StatisticsViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        private string _toLabelText;
        private string _fromLabelText;
        private string _statisticsLabelText;
        private string _generatePDFText;

        public StatisticsViewModel(CultureInfo language)
        {
            Language = language;
        }

        public string ToLabelText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("labelTo", Language);
            }
            set
            {
                _toLabelText = value;
                RaisePropertyChanged("ToLabelText");
            }
        }

        public string FromLabelText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("labelFrom", Language);
            }
            set
            {
                _fromLabelText = value;
                RaisePropertyChanged("FromLabelText");
            }
        }

        public string StatisticsLabelText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("labelStatistics", Language);
            }
            set
            {
                _statisticsLabelText = value;
                RaisePropertyChanged("StatisticsLabelText");
            }
        }

        public string GeneratePDFText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("generatePDFText", Language);
            }
            set
            {
                _generatePDFText = value;
                RaisePropertyChanged("GeneratePDFText");
            }
        }
    }
}
