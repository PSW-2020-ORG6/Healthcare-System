using Backend.Controller.PhysitianControllers;
using Backend.Dto;
using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using Model.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.util;
using HealthClinic.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HealthClinic.FrontendWrapperClasses;
using Model.Hospital;
using health_clinic_class_diagram.Backend.Controller.PhysitianControllers;

namespace HealthClinic.ViewModel
{
    public class SpecialistReferralViewModel : ViewModelBase
    {
        private YesNoDialog submitDialog;
        private YesNoDialog cancelDialog;

        private bool urgency;
        private string notes;
        private Patient patient;

        //NOVO ZA COMBOBOX
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
        //

        private PhysitianScheduleController physitianScheduleController;
        private SpecialistAppointmentSchedulingController specialistAppointmentSchedulingController;
        private ExamController examController;
        private PhysitianHospitalController hospitalController;

        private bool isNewDocument;
        private Visibility appointmentSchedulingMode;

        public bool Urgency { get => urgency; set => urgency = value; }
        public string Notes { get => notes; set => notes = value; }

        public SpecialistReferralViewModel(Patient patient)
        {
            isNewDocument = true;
            appointmentSchedulingMode = Visibility.Visible;
            this.patient = patient;
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];

            physitianScheduleController = new PhysitianScheduleController(loggedPhysitian);
            specialistAppointmentSchedulingController = new SpecialistAppointmentSchedulingController();
            hospitalController = new PhysitianHospitalController();

            ProcedureTypeItems = new ObservableCollection<ComboBoxItemWrapper<ProcedureType>>();
            foreach(ProcedureType procedureType in hospitalController.GetProcedureTypes())
            {
                ProcedureTypeItems.Add(new ComboBoxItemWrapper<ProcedureType>(procedureType));
            }
            selectedProcedureTypeItem = ProcedureTypeItems[0];
            RaisePropertyChanged("SelectedProcedureTypeItem");
            updateComboBoxes();
            
        }

        public SpecialistReferralViewModel(SpecialistReferral specialistReferral)
        {
            isNewDocument = false;
            appointmentSchedulingMode = Visibility.Hidden;
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianScheduleController = new PhysitianScheduleController(loggedPhysitian);
            specialistAppointmentSchedulingController = new SpecialistAppointmentSchedulingController();

            ProcedureType procedureType1 = new ProcedureType("pregled kod opste prakse", 30, new Specialization("opsta praksa"));
            ProcedureType procedureType2 = new ProcedureType("kardioloski pregled", 45, new Specialization("kardiologija"));
            ProcedureType procedureType3 = new ProcedureType("transplantacija kuka", 360, new Specialization("hirurgija"));
            ProcedureType procedureType4 = new ProcedureType("ultrazvuk abdomena", 60, new Specialization("interna medicina"));

            this.notes = specialistReferral.Notes;
            selectedProcedureTypeItem = new ComboBoxItemWrapper<ProcedureType>(specialistReferral.ProcedureType);
        }

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    cancelDialog = new YesNoDialog();
                    cancelDialog.DataContext = this;
                    cancelDialog.Owner = Application.Current.MainWindow;
                    cancelDialog.ShowDialog();
                });
            }
        }
        public ICommand SubmitCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    submitDialog = new YesNoDialog();
                    submitDialog.DataContext = this;
                    submitDialog.Owner = Application.Current.MainWindow;
                    submitDialog.ShowDialog();
                });
            }
        }

        public ICommand YesButtonCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (submitDialog != null)
                    {
                        submitDialog.Close();

                        //TODO: zakazati pregled i dodati currentPatient u appointment
                        DateTime date = selectedDateItem.Item;
                        TimeInterval time = selectedTimeItem.Item;
                        DateTime start = date.AddHours(time.Start.Hour).AddMinutes(time.Start.Minute);
                        DateTime end = date.AddHours(time.End.Hour).AddMinutes(time.End.Minute);
                        TimeInterval dateTime = new TimeInterval(start, end);
                        ProcedureType procedureType = selectedProcedureTypeItem.Item;
                        Physitian physitian = selectedPhysitianItem.Item;
                        Room room = null;

                        foreach(AppointmentDTO a in availableAppointments)
                        {
                            if(a.Physitian.Equals(physitian) && a.Time.Equals(dateTime))
                            {
                                room = a.Room;
                                break;
                            }
                        }

                        AppointmentDTO appointment = new AppointmentDTO { Patient = patient, ProcedureType = procedureType, Physitian = physitian, Urgency = urgency, Time = dateTime, Room = room };
                        physitianScheduleController.NewAppointment(appointment);

                        SpecialistReferral specialistReferral = new SpecialistReferral(DateTime.Today, notes, procedureType, physitian);
                        Messenger.Default.Send<AddDocumentMessage>(new AddDocumentMessage { document = specialistReferral });
                        return;
                    }
                    if (cancelDialog != null)
                    {
                        cancelDialog.Close();
                        Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "ReportView" });
                        return;
                    }
                });
            }
        }

        public ICommand NoButtonCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (submitDialog != null)
                    {
                        submitDialog.Close();
                    }
                    if (cancelDialog != null)
                    {
                        cancelDialog.Close();
                    }
                });
            }
        }

        public bool IsNewDocument { get => isNewDocument; set => isNewDocument = value; }
        public Visibility AppointmentSchedulingMode { get => appointmentSchedulingMode; set => appointmentSchedulingMode = value; }
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
                RaisePropertyChanged("SelectedPhysitianItem");
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
                RaisePropertyChanged("DateItems");
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

        private void updateComboBoxes()
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO { ProcedureType = SelectedProcedureTypeItem.Item, Patient = patient };
            availableAppointments = specialistAppointmentSchedulingController.GetAllAvailableAppointments(appointmentDTO);

            allPhysitianItems = new ObservableCollection<ComboBoxItemWrapper<Physitian>>();
            allPhysitianItems.Add(new ComboBoxItemWrapper<Physitian>(null));
            allDateItems = new ObservableCollection<ComboBoxItemWrapper<DateTime>>();
            allDateItems.Add(new ComboBoxItemWrapper<DateTime>(DateTime.MinValue));
            allTimeItems = new ObservableCollection<ComboBoxItemWrapper<TimeInterval>>();
            allTimeItems.Add(new ComboBoxItemWrapper<TimeInterval>(null));

            foreach(AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);

                if(!allPhysitianItems.Contains(physitian))
                {
                    allPhysitianItems.Add(physitian);
                }
                if(!allDateItems.Contains(date))
                {
                    allDateItems.Add(date);
                }
                if(!allTimeItems.Contains(time))
                {
                    allTimeItems.Add(time);
                }
            }

            physitianItems = allPhysitianItems;
            dateItems = allDateItems;
            timeItems = allTimeItems;

            RaisePropertyChanged("PhysitianItems");
            RaisePropertyChanged("DateItems");
            RaisePropertyChanged("TimeItems");
        }

        private void filterComboboxesForPhysitian()
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

                if (selectedPhysitianItem != null && selectedPhysitianItem.Item != null && !appointment.Physitian.Equals(selectedPhysitianItem.Item))
                {
                    continue;
                }
                if(selectedDateItem != null && !selectedDateItem.Item.Equals(DateTime.MinValue) && !appointment.Date.Equals(selectedDateItem.Item))
                {
                    continue;
                }
                if(selectedTimeItem != null && selectedTimeItem.Item != null && !appointment.Time.TimeOfDayEquals(selectedTimeItem.Item))
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

                //Physitian = physitians;
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
            foreach (AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);

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
            foreach (AppointmentDTO appointment in availableAppointments)
            {
                ComboBoxItemWrapper<Physitian> physitian = new ComboBoxItemWrapper<Physitian>(appointment.Physitian);
                DateTime d = appointment.Time.Start.Date;
                ComboBoxItemWrapper<DateTime> date = new ComboBoxItemWrapper<DateTime>(d);
                TimeInterval t = createTimeIntervalForToday(appointment.Time);
                ComboBoxItemWrapper<TimeInterval> time = new ComboBoxItemWrapper<TimeInterval>(t);

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
            }
        }

        private TimeInterval createTimeIntervalForToday(TimeInterval timeInterval)
        {
            DateTime start = DateTime.Today.AddHours(timeInterval.Start.Hour).AddMinutes(timeInterval.Start.Minute);
            DateTime end = DateTime.Today.AddHours(timeInterval.End.Hour).AddMinutes(timeInterval.End.Minute);
            return new TimeInterval(start, end);
        }

    }
}
