using Backend.Controller.PhysitianControllers;
using Model.Accounts;
using Model.Schedule;
using Model.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.FrontendAdapters;
using HealthClinic.Message;
using HealthClinic.util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PhysicianGUI.View;

namespace HealthClinic.ViewModel
{
    public class PhysitianViewModel : ViewModelBase
    {
        private PhysitianScheduleController physitianScheduleController;
        private ObservableCollection<Appointment> appointments;
        private DateTime selectedDate;
        private Appointment selectedAppointment;
        private Physitian physitian;
        private List<PhysitianStats> chartData;
        private DateTime statisticDisplayMonth;
        private PhysitianScheduleStatisticDialog physitianScheduleStatisticDialog;

        public ObservableCollection<Appointment> Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                appointments = value;
                RaisePropertyChanged("Appointments");
            }
        }
  
        public PhysitianViewModel()
        {
            //TODO: premestiti u login
            physitian = new Physitian("Milica", "Siriski", "789324567", DateTime.Parse("7.7.1998"), "062/123-123", "milica.siriski@zdravo.com", new Address("Topolska 18"), "password");
            Specialization specialization1 = new Specialization("hirurg");
            Specialization specialization2 = new Specialization("kardiolog");
            physitian.AddSpecialization(specialization1);
            physitian.AddSpecialization(specialization2);
            Application.Current.Properties["LoggedPhysitian"] = physitian;

            physitianScheduleController = new PhysitianScheduleController(Physitian);
            SelectedDate = DateTime.Today;
            StatisticDisplayMonth = DateTime.Today;
        }

        private List<PhysitianStats> getChartData(DateTime date)
        {
            List<PhysitianStats> result = new List<PhysitianStats>();
            
            DateTime startOfMonth = date.AddDays(1 - date.Day);
            for (int i = 0; i <= DateTime.DaysInMonth(date.Year, date.Month) - 1; i++)
            {
                DateTime d = startOfMonth.AddDays(i);
                //int n = physitianScheduleController.GetAppointmentsByDate(d).Count;
                int n = 0;
                result.Add(new PhysitianStats(d, n));
            }

            return result;
        }

        public ICommand ChangeToPatientDetailViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<ViewPatientInfoMessage>(new ViewPatientInfoMessage { Patient = selectedAppointment.Patient });
                });
            }
        }

        public ICommand OpenPhysitianScheduleStatisticsDialog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    physitianScheduleStatisticDialog = new PhysitianScheduleStatisticDialog();
                    physitianScheduleStatisticDialog.DataContext = this;
                    physitianScheduleStatisticDialog.Owner = Application.Current.MainWindow;
                    physitianScheduleStatisticDialog.Show();
                });
            }
        }

        public ICommand ClosePhysitianScheduleStatisticsDialog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    physitianScheduleStatisticDialog.Close();
                });
            }
        }

        public ICommand NextStatisticDisplayMonth
        {
            get
            {
                return new RelayCommand(() =>
                {
                    StatisticDisplayMonth = statisticDisplayMonth.AddMonths(1);
                });
            }
        }

        public ICommand PreviousStatisticDisplayMonth
        {
            get
            {
                return new RelayCommand(() =>
                {
                    StatisticDisplayMonth = statisticDisplayMonth.AddMonths(-1);
                });
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                selectedDate = value;
                ObservableListConverter<Appointment> converter = new ObservableListConverter<Appointment>();
                //List<Appointment> appointments = physitianScheduleController.GetAppointmentsByDate(selectedDate);
                List<Appointment> appointments = new List<Appointment>();
                Appointments = converter.ToObservable(appointments);
                RaisePropertyChanged("SelectedDate");
            }
        }

        public Appointment SelectedAppointment
        {
            get
            {
                return selectedAppointment;
            }
            set
            {
                selectedAppointment = value;
                RaisePropertyChanged("SelectedAppointment");
                RaisePropertyChanged("IsExamButtonEnabled");
            }
        }
        public bool IsExamButtonEnabled
        {
            get
            {
                return selectedAppointment != null && selectedDate.Equals(DateTime.Today);
            }
        }

        public Physitian Physitian { get => physitian; set => physitian = value; }
        public List<PhysitianStats> ChartData
        {
            get
            {
                return chartData;
            }
            set
            {
                chartData = value;
                RaisePropertyChanged("ChartData");
            }
        }

        public DateTime StatisticDisplayMonth
        {
            get
            {
                return statisticDisplayMonth;
            }
            set
            {
                statisticDisplayMonth = value;
                ChartData = getChartData(statisticDisplayMonth);
                RaisePropertyChanged("StatisticDisplayMonth");
                RaisePropertyChanged("StatisticLabelText");
            }
        }

        public string StatisticLabelText
        {
            get
            {
                CultureInfo srCulture = CultureInfo.GetCultureInfo("sr-Latn-RS");
                return "Statistika rada za " + StatisticDisplayMonth.ToString("MMMMM", srCulture).ToLower() + " " + StatisticDisplayMonth.Year + "." ;
            }
        }
    }
}
