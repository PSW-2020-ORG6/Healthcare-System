using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;

namespace HealthClinic.ViewModel
{
    class CalendarViewModel : ViewModelBase
    {
        private String _calendarHeading;
        private DateTime _currentDate;
        private String _mode;

        public String CalendarHeading
        {
            get
            {
                return _calendarHeading;
            }
            set
            {
                _calendarHeading = value;
                RaisePropertyChanged("CalendarHeading");
            }
        }
        public DateTime CurrentDate { get => _currentDate; set => _currentDate = value; }

        public CalendarViewModel()
        {
            CurrentDate = DateTime.Today;
            this.refreshCalendarHeading();
            Mode = "mesec";
        }

        public ICommand NextMonthCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentDate = CurrentDate.AddMonths(1);
                    this.refreshCalendarHeading();
                });
            }
        }

        public ICommand PreviousMonthCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentDate = CurrentDate.AddMonths(-1);
                    this.refreshCalendarHeading();
                });
            }
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

        public List<string> CalendarModes
        {
            get
            {
                List<String> calendarModes = new List<string>();
                calendarModes.Add("dan");
                calendarModes.Add("mesec");

                return calendarModes;
            }
        }

        public string Mode { get => _mode; set => _mode = value; }

        private void refreshCalendarHeading()
        {
            CultureInfo srCulture = CultureInfo.GetCultureInfo("sr-Latn-RS");
            CalendarHeading = CurrentDate.ToString("MMMM", srCulture).ToUpper() + " " + CurrentDate.Year;
        }
    }
}
