using Backend.Controller.PhysitianControllers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.util;
using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace HealthClinic.ViewModel
{
    class CalendarDayViewModel : ViewModelBase
    {
        private String _calendarHeading;
        private DateTime _currentDate;
        private String _mode;
        private PhysitianScheduleController physitianScheduleController;

        public CalendarDayViewModel()
        {
            CurrentDate = DateTime.Today;
            this.refreshCalendarHeading();
            Mode = "dan";

            Physitian physitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianScheduleController = new PhysitianScheduleController(physitian);
        }

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
        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                RaisePropertyChanged("CurrentDate");
                this.refreshCalendarHeading();
                RaisePropertyChanged("Exams");
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

        public ObservableCollection<Appointment> Exams
        {
            get
            {
                ObservableListConverter<Appointment> converter = new ObservableListConverter<Appointment>();
                return converter.ToObservable(physitianScheduleController.GetAppointmentsByDate(CurrentDate));
            }
            set
            {
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
        public ICommand NextDayCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentDate = CurrentDate.AddDays(1);
                });
            }
        }

        public ICommand PreviousDayCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentDate = CurrentDate.AddDays(-1);
                });
            }
        }

        public string Mode { get => _mode; set => _mode = value; }

        private void refreshCalendarHeading()
        {
            CultureInfo srCulture = CultureInfo.GetCultureInfo("sr-Latn-RS");
            CalendarHeading = CurrentDate.ToString("ddd", srCulture).ToUpper() + " " + CurrentDate.ToString("dd.MM.yyyy.", srCulture);
        }
    }
}
