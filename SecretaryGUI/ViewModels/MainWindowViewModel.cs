using Model.Accounts;
using Model.Schedule;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using HCI_SIMS_PROJEKAT.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlView;
        private String _titleHeader;
        private String _scheduleSideBar;
        private String _registerSideBar;
        private String _appointmentSideBar;
        private String _physitianListSideBar;
        private String _patientListSideBar;
        private String _statisticsSideBar;
        private String _personalizationSideBar;
        private String currentStyle;
        private CultureInfo Language = CultureInfo.GetCultureInfo("sr-Latn-RS");
        
        public FrameworkElement ContentControlView
        {
            get { return _contentControlView; }
            set
            {
                _contentControlView = value;
                RaisePropertyChanged("ContentControlView");
            }
        }

        public string ScheduleSideBar
        {
            get { return _scheduleSideBar; }
            set
            {
                _scheduleSideBar = value;
                RaisePropertyChanged("ScheduleSideBar");
            }
        }

        public string RegisterSideBar
        {
            get { return _registerSideBar; }
            set
            {
                _registerSideBar = value;
                RaisePropertyChanged("RegisterSideBar");
            }
        }

        public string PhysitianListSideBar
        {
            get { return _physitianListSideBar; }
            set
            {
                _physitianListSideBar = value;
                RaisePropertyChanged("PhysitianListSideBar");
            }
        }

        public string AppointmentSideBar
        {
            get { return _appointmentSideBar; }
            set
            {
                _appointmentSideBar = value;
                RaisePropertyChanged("AppointmentSideBar");
            }
        }

        public string PatientListSideBar
        {
            get { return _patientListSideBar; }
            set
            {
                _patientListSideBar = value;
                RaisePropertyChanged("PatientListSideBar");
            }
        }

        public string StatisticsSideBar
        {
            get { return _statisticsSideBar; }
            set
            {
                _statisticsSideBar = value;
                RaisePropertyChanged("StatisticsSideBar");
            }
        }

        public string PersonalizationSideBar
        {
            get { return _personalizationSideBar; }
            set
            {
                _personalizationSideBar = value;
                RaisePropertyChanged("PersonalizationSideBar");
            }
        }

        public string TitleHeader
        {
            get { return _titleHeader; }
            set
            {
                _titleHeader = value;
                RaisePropertyChanged("TitleHeader");
            }
        }

        public MainWindowViewModel()
        {
            currentStyle = "SkyBlue";
            Application.Current.Resources["menuButtonStyle"] = Application.Current.Resources["MenuButton"];
            Application.Current.Resources["sideBarStyle"] = Application.Current.Resources["WhiteSideBar"];
            Application.Current.Resources["headerStyle"] = Application.Current.Resources["HeaderWhite"];
            Application.Current.Resources["mainStyle"] = Application.Current.Resources["WhiteMainColor"];

            ResourceManager rmInicialization = Properties.Resources.ResourceManager;
            ScheduleSideBar = rmInicialization.GetString("titleHeaderSchedule", Language);
            RegisterSideBar = rmInicialization.GetString("titleHeaderRegistration", Language);
            AppointmentSideBar = rmInicialization.GetString("titleAddAppointment", Language);
            PhysitianListSideBar = rmInicialization.GetString("titlePhysitianList", Language);
            PatientListSideBar = rmInicialization.GetString("titlePatientList", Language);
            StatisticsSideBar = rmInicialization.GetString("titleStatistics", Language);
            PersonalizationSideBar = rmInicialization.GetString("titlePersonalization", Language);

            Messenger.Default.Register<SwitchViewMessage>(this, (switchViewMessage) =>
            {
                SwitchView(switchViewMessage.ViewName);
            });

            SwitchView("MainView");

            Messenger.Default.Register<SwitchStyleMessage>(this, (switchStyleMessage) =>
            {
                SwitchStyle(switchStyleMessage.StyleName);
            });

            Messenger.Default.Register<EditAppointmentMessage>(this, (editAppointmentMessage) =>
            {
                EditAppointment(editAppointmentMessage.appointment);
            });

            Messenger.Default.Register<ChangeLanguageMessage>(this, (ChangeLanguageMessage) =>
            {
                ChangeLanguage(ChangeLanguageMessage.Language);
                ResourceManager rm = Properties.Resources.ResourceManager;
                TitleHeader = rm.GetString("titlePersonalization", Language);
            });

            Messenger.Default.Register<AddAppointmentPatientMessage>(this, (addAppointmentPatinetMessage) =>
            {
                AddAppointmentPatient(addAppointmentPatinetMessage.patient);
            });

        }

        private void EditAppointment(Appointment appointment)
        {
            ResourceManager rm = Properties.Resources.ResourceManager;
            TitleHeader = rm.GetString("titleAddAppointment", Language);
            ContentControlView = new AppointmentView(currentStyle);
            ContentControlView.DataContext = new AppointmentViewModel("ScheduleView", Language, currentStyle, appointment);
        }

        private void AddAppointmentPatient(Patient patient)
        {
            ResourceManager rm = Properties.Resources.ResourceManager;
            TitleHeader = rm.GetString("titleAddAppointment", Language);
            ContentControlView = new AppointmentView(currentStyle);
            ContentControlView.DataContext = new AppointmentViewModel("PatientListView", Language, currentStyle, patient);
        }

        public ICommand ChangeToScheduleViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("ScheduleView");
                });
            }
        }


        public ICommand ChangeToAppointmentViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("AppointmentView");
                });
            }
        }

        public ICommand ChangeToMainViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("MainView");
                });
            }
        }

        public ICommand ChangeToRegisterPatientViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("RegisterPatientView");
                });
            }
        }

        public ICommand ChangeToPersonalizationViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("PersonalizationView");
                });
            }
        }

        public ICommand ChangeToPatientListViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("PatientListView");
                });
            }
        }

        public ICommand ChangeToPhysitianListViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("PhysitianListView");
                });
            }
        }

        public ICommand ChangeToPStatisticsViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SwitchView("StatisticsView");
                });
            }
        }


        public void SwitchView(string viewName)
        {

            ResourceManager rm = Properties.Resources.ResourceManager;

            switch (viewName)
            {
                case "ScheduleView":
                    TitleHeader = rm.GetString("titleHeaderSchedule", Language);
                    ContentControlView = new ScheduleView(currentStyle);
                    ContentControlView.DataContext = new ScheduleViewModel(Language, currentStyle);
                    break;

                case "RegisterPatientView":
                    TitleHeader = rm.GetString("titleHeaderRegistration", Language);
                    ContentControlView = new RegisterPatientView(currentStyle);
                    ContentControlView.DataContext = new RegisterPatientViewModel(Language);
                    break;

                case "AppointmentView":
                    TitleHeader = rm.GetString("titleAddAppointment", Language);
                    ContentControlView = new AppointmentView(currentStyle);
                    ContentControlView.DataContext = new AppointmentViewModel("MainView", Language, currentStyle);
                    break;

                case "AppointmentViewFromSchedule":
                    TitleHeader = rm.GetString("titleAddAppointment", Language);
                    ContentControlView = new AppointmentView(currentStyle);
                    ContentControlView.DataContext = new AppointmentViewModel("ScheduleView", Language, currentStyle);
                    break;

                case "AppointmentViewFromPatient":
                    TitleHeader = rm.GetString("titleAddAppointment", Language);
                    ContentControlView = new AppointmentView(currentStyle);
                    ContentControlView.DataContext = new AppointmentViewModel("PatientListView", Language, currentStyle);
                    break;

                case "MainView":
                    TitleHeader = "Klinika-Zdravo";
                    ContentControlView = new MainView(currentStyle);
                    ContentControlView.DataContext = new MainViewModel(Language);
                    break;

                case "PersonalizationView":
                    TitleHeader = rm.GetString("titlePersonalization", Language);
                    ContentControlView = new PersonalizationView(currentStyle, Language);
                    ContentControlView.DataContext = new PersonalizationViewModel(Language);
                    break;

                case "PatientListView":
                    TitleHeader = rm.GetString("titlePatientList", Language);
                    ContentControlView = new PatientListView(currentStyle);
                    ContentControlView.DataContext = new PatientListViewModel(Language, currentStyle);
                    break;

                case "PhysitianListView":
                    TitleHeader = rm.GetString("titlePhysitianList", Language);
                    ContentControlView = new PhysitianListView(currentStyle);
                    ContentControlView.DataContext = new PhysitianListViewModel(Language);
                    break;

                case "StatisticsView":
                    TitleHeader = rm.GetString("titleStatistics", Language);
                    ContentControlView = new StatisticsView(currentStyle);
                    ContentControlView.DataContext = new StatisticsViewModel(Language);
                    break;
            }
        }

        public void SwitchStyle(String styleName)
        {
            currentStyle = styleName;

            switch(styleName)
            {
                case "SkyBlue":
                    Application.Current.Resources["menuButtonStyle"] = Application.Current.Resources["MenuButton"];
                    Application.Current.Resources["sideBarStyle"] = Application.Current.Resources["WhiteSideBar"];
                    Application.Current.Resources["headerStyle"] = Application.Current.Resources["HeaderWhite"];
                    Application.Current.Resources["mainStyle"] = Application.Current.Resources["WhiteMainColor"];
                    
                    break;
                case "DarkPurple":
                    Application.Current.Resources["menuButtonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Application.Current.Resources["sideBarStyle"] = Application.Current.Resources["DarkSideBar"];
                    Application.Current.Resources["headerStyle"] = Application.Current.Resources["HeaderBlack"];
                    Application.Current.Resources["mainStyle"] = Application.Current.Resources["DarkMainColor"];
                    
                    break;
            }
        }

        public void ChangeLanguage(CultureInfo Language)
        {
            this.Language = Language;
            ResourceManager rmChange = Properties.Resources.ResourceManager;
            ScheduleSideBar = rmChange.GetString("titleHeaderSchedule", Language);
            RegisterSideBar = rmChange.GetString("titleHeaderRegistration", Language);
            AppointmentSideBar = rmChange.GetString("titleAddAppointment", Language);
            PhysitianListSideBar = rmChange.GetString("titlePhysitianList", Language);
            PatientListSideBar = rmChange.GetString("titlePatientList", Language);
            StatisticsSideBar = rmChange.GetString("titleStatistics", Language);
            PersonalizationSideBar = rmChange.GetString("titlePersonalization", Language);
        }
    }
}