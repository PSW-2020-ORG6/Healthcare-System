using Backend.Controller.SecretaryControllers;
using Backend.Dto;
using Model.Accounts;
using Model.Hospital;
using Model.Schedule;
using Backend.Model.Util;
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
using Model.Util;

namespace HCI_SIMS_PROJEKAT.ViewModels
{
    class AppointmentViewModel : ViewModelBase
    {
        private String _viewCallerName;
        public static CultureInfo Language;
        public String styleName;
        private String _generateAppointmentText;
        private String _dateText;
        private String _timeText;
        private String _procedureTypeText;
        private String _physitianText;
        private String _roomText;
        private String _emergencyText;
        private String _yesText;
        private String _noText;
        private String _patientText;
        private String _fromText;
        private String _toText;
        private String _choosePatientText;
        private String _submitButtonText;
        private String _declineButtonText;

        private DateTime _time;
        private Patient _patient;
        private DateTime _date;
        private ProcedureType _procedureType;
        private Physitian _physitian;
        private SecretaryHospitalController secretaryHospitalController;
        private SecretaryScheduleController secretaryScheduleController;
        private Room _room;
        private bool _emergency;
        private bool _editAppointment;

        private Appointment _oldAppointment;

        //ObservableListConverter<Physitian> observableListConverter = new ObservableListConverter<Physitian>();
        //ObservableListConverter<Room> observableListConverterRoom = new ObservableListConverter<Room>();
        //ObservableListConverter<ProcedureType> observableListConverterProcedureType = new ObservableListConverter<ProcedureType>();
        ObservableListConverter<Patient> observableListConverterPatient = new ObservableListConverter<Patient>();
        //private ObservableCollection<ProcedureType> procedureTypes;
        //private ObservableCollection<Physitian> physitians;
        //private ObservableCollection<Room> rooms;

        private List<AppointmentDTO> availableAppointments;
        private ObservableCollection<ComboBoxItemWrapper<ProcedureType>> procedureTypeItems;
        private ComboBoxItemWrapper<ProcedureType> selectedProcedureTypeItem;

        private ObservableCollection<ComboBoxItemWrapper<Physitian>> allPhysitianItems;
        private ObservableCollection<ComboBoxItemWrapper<Physitian>> physitianItems;
        private ComboBoxItemWrapper<Physitian> selectedPhysitianItem;

        private ObservableCollection<ComboBoxItemWrapper<DateTime>> allDateItems;
        private ObservableCollection<ComboBoxItemWrapper<DateTime>> dateItems;
        private ComboBoxItemWrapper<DateTime> selectedDateItem;

        private ObservableCollection<ComboBoxItemWrapper<TimeInterval>> allTimeItems;
        private ObservableCollection<ComboBoxItemWrapper<TimeInterval>> timeItems;
        private ComboBoxItemWrapper<TimeInterval> selectedTimeItem;

        private ObservableCollection<ComboBoxItemWrapper<Room>> allRoomItems;
        private ObservableCollection<ComboBoxItemWrapper<Room>> roomItems;
        private ComboBoxItemWrapper<Room> selectedRoomItem;


        public AppointmentViewModel(String viewCallerName, CultureInfo language, String styleName)
        {
            secretaryHospitalController = new SecretaryHospitalController();
            secretaryScheduleController = new SecretaryScheduleController();

            _viewCallerName = viewCallerName;
            Language = language;
            this.styleName = styleName;

            if (!(observableListConverterPatient.ToObservable(secretaryHospitalController.GetAllPatients()).Count == 0))
            {
                _patient = observableListConverterPatient.ToObservable(secretaryHospitalController.GetAllPatients())[0];
            }

            ProcedureTypeItems = new ObservableCollection<ComboBoxItemWrapper<ProcedureType>>();
            foreach (ProcedureType procedureType in secretaryHospitalController.GetAllProcedureTypes())
            {
                ProcedureTypeItems.Add(new ComboBoxItemWrapper<ProcedureType>(procedureType));
            }

            selectedProcedureTypeItem = ProcedureTypeItems[0];
            RaisePropertyChanged("SelectedProcedureTypeItem");
            updateComboBoxes();

            Messenger.Default.Register<ChoosePatientMessage>(this, (choosePatientMessage) =>
            {
                Patient = choosePatientMessage.patient;
            });
        }

        public AppointmentViewModel(String viewCallerName, CultureInfo language, String styleName, Patient patient)
        {
            secretaryHospitalController = new SecretaryHospitalController();
            secretaryScheduleController = new SecretaryScheduleController();

            _viewCallerName = viewCallerName;
            Language = language;
            this.styleName = styleName;

            _patient = patient;
            RaisePropertyChanged("Patient");

            ProcedureTypeItems = new ObservableCollection<ComboBoxItemWrapper<ProcedureType>>();
            foreach (ProcedureType procedureType in secretaryHospitalController.GetAllProcedureTypes())
            {
                ProcedureTypeItems.Add(new ComboBoxItemWrapper<ProcedureType>(procedureType));
            }

            selectedProcedureTypeItem = ProcedureTypeItems[0];
            RaisePropertyChanged("SelectedProcedureTypeItem");
            updateComboBoxes();

            Messenger.Default.Register<ChoosePatientMessage>(this, (choosePatientMessage) =>
            {
                Patient = choosePatientMessage.patient;
            });
        }


        public AppointmentViewModel(String viewCallerName, CultureInfo language, String styleName, Appointment appointment)
        { // ovde je stigao appointment.
            secretaryHospitalController = new SecretaryHospitalController();
            secretaryScheduleController = new SecretaryScheduleController();

            _viewCallerName = viewCallerName;
            Language = language;
            this.styleName = styleName;

            _editAppointment = true;

            AppointmentDTO appointmentDTO = new AppointmentDTO { Time = appointment.TimeInterval, Date = appointment.Date, Patient = appointment.Patient, Physitian = appointment.Physitian, ProcedureType = appointment.ProcedureType, Room = appointment.Room, Urgency = appointment.Urgency };

            _oldAppointment = new Appointment(appointmentDTO);
            _oldAppointment.SerialNumber = appointment.SerialNumber;

            ProcedureTypeItems = new ObservableCollection<ComboBoxItemWrapper<ProcedureType>>();
            foreach (ProcedureType procedureType in secretaryHospitalController.GetAllProcedureTypes())
            {
                ProcedureTypeItems.Add(new ComboBoxItemWrapper<ProcedureType>(procedureType));
            }

            selectedProcedureTypeItem = ProcedureTypeItems[0];
            RaisePropertyChanged("SelectedProcedureTypeItem");
            _patient = appointment.Patient;

            updateComboBoxes();

            Emergency = appointment.Urgency;
            selectedRoomItem = new ComboBoxItemWrapper<Room>(appointment.Room);
            selectedPhysitianItem = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
            selectedDateItem = new ComboBoxItemWrapper<DateTime>(appointment.TimeInterval.Start.Date);
            selectedTimeItem = new ComboBoxItemWrapper<TimeInterval>(createTimeIntervalForToday(appointment.TimeInterval));

            Messenger.Default.Register<ChoosePatientMessage>(this, (choosePatientMessage) =>
            {
                Patient = choosePatientMessage.patient;
            });

            RaisePropertyChanged("SelectedDateItem");
            RaisePropertyChanged("SelectedTimeItem");
            RaisePropertyChanged("SelectedProcedureTypeItem");
            RaisePropertyChanged("SelectedPhysitianItem");
            RaisePropertyChanged("SelectedRoomItem");
            RaisePropertyChanged("Patient");
        }

        public ComboBoxItemWrapper<ProcedureType> SelectedProcedureTypeItem
        {
            get
            {
                return selectedProcedureTypeItem;
            }
            set
            {
                selectedProcedureTypeItem = value;
                selectedPhysitianItem = null;
                RaisePropertyChanged("SelectedPhysitianItem");
                selectedDateItem = null;
                RaisePropertyChanged("SelectedDateItem");
                selectedTimeItem = null;
                RaisePropertyChanged("SelectedTimeItem");
                RaisePropertyChanged("SelectedProcedureTypeItem");
                updateComboBoxes();
            }
        }

        public ObservableCollection<ComboBoxItemWrapper<ProcedureType>> ProcedureTypeItems
        {
            get
            {
                return procedureTypeItems;
            }
            set
            {
                procedureTypeItems = value;
            }
        }

        public ObservableCollection<ComboBoxItemWrapper<TimeInterval>> TimeItems
        {
            get
            {
                return timeItems;
            }
            set
            {
                timeItems = value;
                RaisePropertyChanged("TimeItems");
            }
        }

        public ComboBoxItemWrapper<TimeInterval> SelectedTimeItem
        {
            get
            {
                return selectedTimeItem;
            }
            set
            {
                selectedTimeItem = value;
                RaisePropertyChanged("SelectedTimeItem");
                filterComboboxesForTime();
            }
        }

        public ObservableCollection<ComboBoxItemWrapper<Physitian>> PhysitianItems
        {
            get
            {
                return physitianItems;
            }
            set
            {
                physitianItems = value;
                RaisePropertyChanged("PhysitianItems");
            }
        }

        public ComboBoxItemWrapper<Physitian> SelectedPhysitianItem
        {
            get
            {
                return selectedPhysitianItem;
            }
            set
            {
                selectedPhysitianItem = value;
                RaisePropertyChanged("PhysitianTimeItem");
                filterComboboxesForPhysitian();
            }
        }

        public ObservableCollection<ComboBoxItemWrapper<DateTime>> DateItems
        {
            get
            {
                return dateItems;
            }
            set
            {
                dateItems = value;
                RaisePropertyChanged("DateTimeItems");
            }
        }

        public ComboBoxItemWrapper<DateTime> SelectedDateItem
        {
            get
            {
                return selectedDateItem;
            }
            set
            {
                selectedDateItem = value;
                RaisePropertyChanged("SelectedDateItem");
                filterComboboxesForDate();
            }
        }

        public ObservableCollection<ComboBoxItemWrapper<Room>> RoomItems
        {
            get
            {
                return roomItems;
            }
            set
            {
                roomItems = value;
                RaisePropertyChanged("RoomItems");
            }
        }

        public ComboBoxItemWrapper<Room> SelectedRoomItem
        {
            get
            {
                return selectedRoomItem;
            }
            set
            {
                selectedRoomItem = value;
                RaisePropertyChanged("SelectedRoomItem");
                filterComboboxesForRoom();
            }
        }

        private void updateComboBoxes()
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO { ProcedureType = SelectedProcedureTypeItem.Item, Patient = _patient };
            availableAppointments = secretaryScheduleController.GetAllAvailableAppointments(appointmentDTO);
            
            if(_editAppointment == true)
            {
                availableAppointments.Add(new AppointmentDTO { Time = _oldAppointment.TimeInterval,
                    Date = _oldAppointment.Date, Patient = _oldAppointment.Patient, Physitian = _oldAppointment.Physitian, ProcedureType = _oldAppointment.ProcedureType, Room = _oldAppointment.Room, Urgency = _oldAppointment.Urgency });
            }
            

            allPhysitianItems = new ObservableCollection<ComboBoxItemWrapper<Physitian>>();
            allPhysitianItems.Add(new ComboBoxItemWrapper<Physitian>(null));
            allDateItems = new ObservableCollection<ComboBoxItemWrapper<DateTime>>();
            allDateItems.Add(new ComboBoxItemWrapper<DateTime>(DateTime.MinValue));
            allTimeItems = new ObservableCollection<ComboBoxItemWrapper<TimeInterval>>();
            allTimeItems.Add(new ComboBoxItemWrapper<TimeInterval>(null));
            allRoomItems = new ObservableCollection<ComboBoxItemWrapper<Room>>();
            allRoomItems.Add(new ComboBoxItemWrapper<Room>(null));


            foreach (AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                ComboBoxItemWrapper<Room> room = new ComboBoxItemWrapper<Room>(appointment.Room);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);

                if (!allPhysitianItems.Contains(physitian))
                {
                    allPhysitianItems.Add(physitian);
                }
                if (!allDateItems.Contains(date))
                {
                    allDateItems.Add(date);
                }
                if (!allTimeItems.Contains(time))
                {
                    allTimeItems.Add(time);
                }
                if (!allRoomItems.Contains(room))
                {
                    allRoomItems.Add(room);
                }
            }

            physitianItems = allPhysitianItems;
            dateItems = allDateItems;
            timeItems = allTimeItems;
            roomItems = allRoomItems;

            RaisePropertyChanged("PhysitianItems");
            RaisePropertyChanged("DateItems");
            RaisePropertyChanged("TimeItems");
            RaisePropertyChanged("RoomItems");

        }

        private void filterComboboxesForRoom()
        {
            ObservableCollection<ComboBoxItemWrapper<Physitian>> physitians = new ObservableCollection<ComboBoxItemWrapper<Physitian>>();
            physitians.Add(new ComboBoxItemWrapper<Physitian>(null));
            ObservableCollection<ComboBoxItemWrapper<DateTime>> dates = new ObservableCollection<ComboBoxItemWrapper<DateTime>>();
            dates.Add(new ComboBoxItemWrapper<DateTime>(DateTime.MinValue));
            ObservableCollection<ComboBoxItemWrapper<TimeInterval>> times = new ObservableCollection<ComboBoxItemWrapper<TimeInterval>>();
            times.Add(new ComboBoxItemWrapper<TimeInterval>(null));
            

            foreach (AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);
                ComboBoxItemWrapper<Room> room = new ComboBoxItemWrapper<Room>(appointment.Room);

                if (selectedPhysitianItem != null && selectedPhysitianItem.Item != null && !appointment.Physitian.Equals(selectedPhysitianItem.Item))
                {
                    continue;
                }
                if (selectedDateItem != null && !selectedDateItem.Item.Equals(DateTime.MinValue) && !appointment.Date.Equals(selectedDateItem.Item))
                {
                    continue;
                }
                if (selectedTimeItem != null && selectedTimeItem.Item != null && !appointment.Time.TimeOfDayEquals(selectedTimeItem.Item))
                {
                    continue;
                }
                if (selectedRoomItem != null && selectedRoomItem.Item != null && !appointment.Room.Equals(selectedRoomItem.Item))
                {
                    continue;
                }

                if (!physitians.Contains(physitian))
                {
                    physitians.Add(physitian);
                }
                if (!dates.Contains(date))
                {
                    dates.Add(date);
                }
                if (!times.Contains(time))
                {
                    times.Add(time);
                }


                PhysitianItems = physitians;
                DateItems = dates;
                TimeItems = times;
            }
        }

        private void filterComboboxesForPhysitian()
        {
            ObservableCollection<ComboBoxItemWrapper<Physitian>> physitians = new ObservableCollection<ComboBoxItemWrapper<Physitian>>();
            physitians.Add(new ComboBoxItemWrapper<Physitian>(null));
            ObservableCollection<ComboBoxItemWrapper<DateTime>> dates = new ObservableCollection<ComboBoxItemWrapper<DateTime>>();
            dates.Add(new ComboBoxItemWrapper<DateTime>(DateTime.MinValue));
            ObservableCollection<ComboBoxItemWrapper<TimeInterval>> times = new ObservableCollection<ComboBoxItemWrapper<TimeInterval>>();
            times.Add(new ComboBoxItemWrapper<TimeInterval>(null));
            ObservableCollection<ComboBoxItemWrapper<Room>> rooms = new ObservableCollection<ComboBoxItemWrapper<Room>>();
            rooms.Add(new ComboBoxItemWrapper<Room>(null));

            foreach (AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);
                ComboBoxItemWrapper<Room> room = new ComboBoxItemWrapper<Room>(appointment.Room);

                if (selectedPhysitianItem != null && selectedPhysitianItem.Item != null && !appointment.Physitian.Equals(selectedPhysitianItem.Item))
                {
                    continue;
                }
                if (selectedDateItem != null && !selectedDateItem.Item.Equals(DateTime.MinValue) && !appointment.Date.Equals(selectedDateItem.Item))
                {
                    continue;
                }
                if (selectedTimeItem != null && selectedTimeItem.Item != null && !appointment.Time.TimeOfDayEquals(selectedTimeItem.Item))
                {
                    continue;
                }
                if (selectedRoomItem != null && selectedRoomItem.Item != null && !appointment.Room.Equals(selectedRoomItem.Item))
                {
                    continue;
                }

                if (!physitians.Contains(physitian))
                {
                    physitians.Add(physitian);
                }
                if (!dates.Contains(date))
                {
                    dates.Add(date);
                }
                if (!times.Contains(time))
                {
                    times.Add(time);
                }
                if (!rooms.Contains(room))
                {
                    rooms.Add(room);
                }

                RoomItems = rooms;
                DateItems = dates;
                TimeItems = times;
            }
        }

        private void filterComboboxesForDate()
        {
            ObservableCollection<ComboBoxItemWrapper<Physitian>> physitians = new ObservableCollection<ComboBoxItemWrapper<Physitian>>();
            physitians.Add(new ComboBoxItemWrapper<Physitian>(null));
            ObservableCollection<ComboBoxItemWrapper<DateTime>> dates = new ObservableCollection<ComboBoxItemWrapper<DateTime>>();
            dates.Add(new ComboBoxItemWrapper<DateTime>(DateTime.MinValue));
            ObservableCollection<ComboBoxItemWrapper<TimeInterval>> times = new ObservableCollection<ComboBoxItemWrapper<TimeInterval>>();
            times.Add(new ComboBoxItemWrapper<TimeInterval>(null));
            ObservableCollection<ComboBoxItemWrapper<Room>> rooms = new ObservableCollection<ComboBoxItemWrapper<Room>>();
            rooms.Add(new ComboBoxItemWrapper<Room>(null));

            foreach (AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                ComboBoxItemWrapper<Room> room = new ComboBoxItemWrapper<Room>(appointment.Room);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);

                if (selectedPhysitianItem != null && selectedPhysitianItem.Item != null && !appointment.Physitian.Equals(selectedPhysitianItem.Item))
                {
                    continue;
                }
                if (selectedRoomItem != null && selectedRoomItem.Item != null && !appointment.Room.Equals(selectedRoomItem.Item))
                {
                    continue;
                }
                if (selectedDateItem != null && !selectedDateItem.Item.Equals(DateTime.MinValue) && !appointment.Date.Equals(selectedDateItem.Item))
                {
                    continue;
                }
                if (selectedTimeItem != null && selectedTimeItem.Item != null && !appointment.Time.TimeOfDayEquals(selectedTimeItem.Item))
                {
                    continue;
                }

                if (!physitians.Contains(physitian))
                {
                    physitians.Add(physitian);
                }
                if (!dates.Contains(date))
                {
                    dates.Add(date);
                }
                if (!times.Contains(time))
                {
                    times.Add(time);
                }
                if (!rooms.Contains(room))
                {
                    rooms.Add(room);
                }

                PhysitianItems = physitians;
                RoomItems = rooms;
                TimeItems = times;
            }
        }

        private void filterComboboxesForTime()
        {
            ObservableCollection<ComboBoxItemWrapper<Physitian>> physitians = new ObservableCollection<ComboBoxItemWrapper<Physitian>>();
            physitians.Add(new ComboBoxItemWrapper<Physitian>(null));
            ObservableCollection<ComboBoxItemWrapper<DateTime>> dates = new ObservableCollection<ComboBoxItemWrapper<DateTime>>();
            dates.Add(new ComboBoxItemWrapper<DateTime>(DateTime.MinValue));
            ObservableCollection<ComboBoxItemWrapper<TimeInterval>> times = new ObservableCollection<ComboBoxItemWrapper<TimeInterval>>();
            times.Add(new ComboBoxItemWrapper<TimeInterval>(null));
            ObservableCollection<ComboBoxItemWrapper<Room>> rooms = new ObservableCollection<ComboBoxItemWrapper<Room>>();
            rooms.Add(new ComboBoxItemWrapper<Room>(null));

            foreach (AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                ComboBoxItemWrapper<Room> room = new ComboBoxItemWrapper<Room>(appointment.Room);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);

                if (selectedPhysitianItem != null && selectedPhysitianItem.Item != null && !appointment.Physitian.Equals(selectedPhysitianItem.Item))
                {
                    continue;
                }
                if (selectedRoomItem != null && selectedRoomItem.Item != null && !appointment.Room.Equals(selectedRoomItem.Item))
                {
                    continue;
                }
                if (selectedDateItem != null && !selectedDateItem.Item.Equals(DateTime.MinValue) && !appointment.Date.Equals(selectedDateItem.Item))
                {
                    continue;
                }
                if (selectedTimeItem != null && selectedTimeItem.Item != null && !appointment.Time.TimeOfDayEquals(selectedTimeItem.Item))
                {
                    continue;
                }

                if (!physitians.Contains(physitian))
                {
                    physitians.Add(physitian);
                }
                if (!dates.Contains(date))
                {
                    dates.Add(date);
                }
                if (!times.Contains(time))
                {
                    times.Add(time);
                }
                if (!rooms.Contains(room))
                {
                    rooms.Add(room);
                }

                PhysitianItems = physitians;
                DateItems = dates;
                RoomItems = rooms;
            }
        }


        private TimeInterval createTimeIntervalForToday(TimeInterval timeInterval)
        {
            DateTime start = DateTime.Today.AddHours(timeInterval.Start.Hour).AddMinutes(timeInterval.Start.Minute);
            DateTime end = DateTime.Today.AddHours(timeInterval.End.Hour).AddMinutes(timeInterval.End.Minute);
            return new TimeInterval(start, end);
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

        public void showDialog()
        {
            PatientListDialog patientListDialog = new PatientListDialog(styleName);
            patientListDialog.DataContext = new PatientListDialogViewModel(Language);
            patientListDialog.Owner = Application.Current.MainWindow;
            patientListDialog.ShowDialog();
        }

        public ICommand CreateAppointmentCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CreateAppointment();
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "ScheduleView" });
                });
            }
        }

        private void CreateAppointment()
        {

            DateTime start = SelectedDateItem.Item.AddMinutes(SelectedTimeItem.Item.Start.Minute).AddHours(SelectedTimeItem.Item.Start.Hour);
            DateTime end = start.AddMinutes(SelectedProcedureTypeItem.Item.EstimatedTimeInMinutes);
            TimeInterval timeInterval = new TimeInterval(start, end);

            Console.WriteLine(SelectedRoomItem.Item);
            AppointmentDTO appointmentDTO = new AppointmentDTO { Time = timeInterval, Patient = _patient, Physitian = SelectedPhysitianItem.Item, ProcedureType = SelectedProcedureTypeItem.Item, Room = SelectedRoomItem.Item, Urgency = _emergency };

            secretaryScheduleController = new SecretaryScheduleController();

            if (!_editAppointment)
            {
                secretaryScheduleController.NewAppointment(appointmentDTO);
            }
            else
            {
                Appointment newAppointment = new Appointment(appointmentDTO);
                newAppointment.SerialNumber = _oldAppointment.SerialNumber;
                secretaryScheduleController.EditAppointment(newAppointment);
            }

        }

        public string GenerateAppointmentText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("generateAppointmentText", Language);
            }
            set
            {
                _generateAppointmentText = value;
                RaisePropertyChanged("GenerateAppointmentText");
            }
        }

        public string DateText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("dateText", Language);
            }
            set
            {
                _dateText = value;
                RaisePropertyChanged("DateText");
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

        public string ProcedureTypeText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("procedureTypeText", Language);
            }
            set
            {
                _procedureTypeText = value;
                RaisePropertyChanged("ProcedureTypeText");
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

        public string YesText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("yesText", Language);
            }
            set
            {
                _yesText = value;
                RaisePropertyChanged("YesText");
            }
        }

        public string NoText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("noText", Language);
            }
            set
            {
                _noText = value;
                RaisePropertyChanged("NoText");
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

        public string FromText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("labelFrom", Language);
            }
            set
            {
                _fromText = value;
                RaisePropertyChanged("FromText");
            }
        }

        public string ToText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("labelTo", Language);
            }
            set
            {
                _toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        public string ChoosePatientText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("choosePatientText", Language);
            }
            set
            {
                _choosePatientText = value;
                RaisePropertyChanged("ChoosePatientText");
            }
        }

        public string SubmitButtonText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("submitButtonText", Language);
            }
            set
            {
                _submitButtonText = value;
                RaisePropertyChanged("SubmitButtonText");
            }
        }

        public string DeclineButtonText
        {
            get
            {
                ResourceManager rm = Properties.Resources.ResourceManager;
                return rm.GetString("declineButtonText", Language);
            }
            set
            {
                _declineButtonText = value;
                RaisePropertyChanged("DeclineButtonText");
            }
        }

        public ICommand GoBackCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = _viewCallerName });
                });
            }
        }

        public Patient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                updateComboBoxes();
                RaisePropertyChanged("Patient");
            }
        }

        public bool Emergency
        {
            get
            {
                return _emergency;
            }
            set
            {
                _emergency = value;
                RaisePropertyChanged("Emergency");
            }
        }

    }
}
