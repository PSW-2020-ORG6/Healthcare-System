using Backend.Controller.SecretaryControllers;
using Model.Accounts;
using Model.Hospital;
using Model.Schedule;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using HCI_SIMS_PROJEKAT.Util;
using HCI_SIMS_PROJEKAT.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace HCI_SIMS_PROJEKAT.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        public static CultureInfo Language;
        private String styleName;
        private String _addAppointmentText;
        private String _editAppointmentText;
        private String _deleteAppointmentText;
        private String _timeText;
        private String _roomText;
        private String _physitianText;
        private String _patientText;
        private String _typeText;
        private String _emergencyText;
        private bool switchSchedule;
        private ObservableCollection<Appointment> appointments;
        private ObservableCollection<Appointment> allAppointments;
        private SecretaryScheduleController secretaryScheduleController;

        private DateTime selectedDate;
        private Physitian _selectedPhysitian;
        private Room _selectedRoom;

        private SecretaryHospitalController secretaryHospitalController;
        ObservableListConverter<Physitian> observableListConverter = new ObservableListConverter<Physitian>();
        private ObservableCollection<Physitian> physitians;

        ObservableListConverter<Room> observableListConverterRoom = new ObservableListConverter<Room>();
        private ObservableCollection<Room> rooms;

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

        public ObservableCollection<Appointment> SearchedAppointments
        {
            get;
            set;
        }

        public ScheduleViewModel(CultureInfo language, String styleName)
        {

            this.styleName = styleName;

            Language = language;
            Appointments = new ObservableCollection<Appointment>();
            SearchedAppointments = new ObservableCollection<Appointment>();
            allAppointments = Appointments;
            secretaryScheduleController = new SecretaryScheduleController();
            secretaryHospitalController = new SecretaryHospitalController();
            _selectedPhysitian = Physitians[0];
            _selectedRoom = Rooms[0];
            SelectedDate = DateTime.Today;


            Messenger.Default.Register<DeleteAppointmentMessage>(this, (deleteAppointmentMessage) =>
            {
                if (deleteAppointmentMessage.appointment == null)
                {
                    return;
                }

                Console.WriteLine(deleteAppointmentMessage.appointment.Physitian);
                Console.WriteLine(deleteAppointmentMessage.appointment.TimeInterval.Start.Date);
                secretaryScheduleController.DeleteAppointment(deleteAppointmentMessage.appointment);
                updateSchedule(deleteAppointmentMessage.appointment.TimeInterval.Start.Date);
            });

            Messenger.Default.Register<EditAppointmentMessageViewModel>(this, (editAppointmentMessageViewModel) =>
            {
                Messenger.Default.Send<EditAppointmentMessage>(new EditAppointmentMessage { appointment = editAppointmentMessageViewModel.appointment });
            });

            updateSchedule(DateTime.Today);

        }

        private void updateSchedule(DateTime date)
        {
            ObservableListConverter<Appointment> converter = new ObservableListConverter<Appointment>();
            Appointments = converter.ToObservable(secretaryScheduleController.GetAppointmentsByDate(date));

            allAppointments = Appointments;

            SearchedAppointments.Clear();

            if (_selectedPhysitian.ToString().Equals(" ") && _selectedRoom.ToString().Equals("Soba"))
            {
                Appointments = allAppointments;
                return;
            }

            if (_selectedRoom.ToString().Equals("Soba") && !_selectedPhysitian.ToString().Equals("Lekar "))
            {
                foreach (Appointment a in allAppointments)
                {
                    if (a.Physitian.Equals(_selectedPhysitian))
                    {
                        SearchedAppointments.Add(a);
                    }
                }

                Appointments = SearchedAppointments;
                return;
            }

            if (_selectedPhysitian.ToString().Equals("Lekar ") && !_selectedRoom.ToString().Equals("Soba"))
            {
                foreach (Appointment a in allAppointments)
                {
                    if (a.Room.Equals(_selectedRoom))
                    {
                        SearchedAppointments.Add(a);
                    }
                }

                Appointments = SearchedAppointments;
                return;
            }

            if(!_selectedPhysitian.ToString().Equals("Lekar ") && !_selectedRoom.ToString().Equals("Soba"))
            {

                foreach (Appointment a in allAppointments)
                {
                    if (a.Room.Equals(_selectedRoom))
                    {
                        if (a.Physitian.Equals(_selectedPhysitian))
                        {
                            SearchedAppointments.Add(a);
                        }
                    }
                }
                Appointments = SearchedAppointments;
                return;
            }
        }

        public string AddAppointmentText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("appointmentAddButton", Language);
            }
            set
            {
                _addAppointmentText = value;
                RaisePropertyChanged("AddAppointmentText");
            }
        }

        public string DeleteAppointmentText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("deleteButtonText", Language);
            }
            set
            {
                _deleteAppointmentText = value;
                RaisePropertyChanged("DeleteAppotintmentText");
            }
        }

        public string EditAppointmentText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("appointmentChangeButton", Language);
            }
            set
            {
                _editAppointmentText = value;
                RaisePropertyChanged("AddAppointmentText");
            }
        }

        public string TimeText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("timeText", Language);
            }
            set
            {
                _timeText = value;
                RaisePropertyChanged("TimeText");
            }
        }

        public string RoomText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("roomText", Language);
            }
            set
            {
                _roomText = value;
                RaisePropertyChanged("RoomText");
            }
        }

        public string PhysitianText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("physitianText", Language);
            }
            set
            {
                _physitianText = value;
                RaisePropertyChanged("PhysitianText");
            }
        }

        public string PatientText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("patientText", Language);
            }
            set
            {
                _patientText = value;
                RaisePropertyChanged("PatientText");
            }
        }

        public string TypeText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("typeText", Language);
            }
            set
            {
                _typeText = value;
                RaisePropertyChanged("TypeText");
            }
        }

        public string EmergencyText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("emergencyText", Language);
            }
            set
            {
                _emergencyText = value;
                RaisePropertyChanged("EmergencyText");
            }
        }

        public ICommand ChangeToAppointmentViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "AppointmentViewFromSchedule" });
                });
            }
        }

        public ICommand InstantiateDialog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    showDialog();
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
                RaisePropertyChanged("SelectedDate");
                updateSchedule(selectedDate);
            }
        }

        public int SelectedPhysitian
        {
            get
            {
                if (_selectedPhysitian == null)
                {
                    return 0;
                }
                for (int i = 0; i < Physitians.Count; i++)
                {
                    if (_selectedPhysitian.Equals(Physitians[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                _selectedPhysitian = Physitians[value];
                RaisePropertyChanged("Physitian");
                updateSchedule(selectedDate);
            }
        }

        public ObservableCollection<Physitian> Physitians
        {
            get
            {
                return observableListConverter.ToObservable(secretaryHospitalController.GetAllPhysitians());
            }
            set
            {
                physitians = value;
                RaisePropertyChanged("Physitians");
            }
        }

        public int SelectedRoom
        {
            get
            {
                if (_selectedRoom == null)
                {
                    return 0;
                }
                for (int i = 0; i < Rooms.Count; i++)
                {
                    if (_selectedRoom.Equals(Rooms[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                _selectedRoom = Rooms[value];
                RaisePropertyChanged("Room");
                updateSchedule(selectedDate);
            }
        }

        public ObservableCollection<Room> Rooms
        {
            get
            {
                return observableListConverterRoom.ToObservable(secretaryHospitalController.GetAllRooms());
            }
            set
            {
                rooms = value;
                RaisePropertyChanged("Rooms");
            }
        }

        public void showDialog()
        {
            DeleteAppointmentDialog deleteAppointmentDialog = new DeleteAppointmentDialog(styleName);
            deleteAppointmentDialog.DataContext = new DeleteAppointmentDialogViewModel(Language);
            deleteAppointmentDialog.Owner = Application.Current.MainWindow;
            deleteAppointmentDialog.ShowDialog();
        }
    }
}
