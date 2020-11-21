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

namespace HealthClinic.ViewModel
{
    public class FollowUpViewModel : ViewModelBase
    {
        private YesNoDialog submitDialog;
        private YesNoDialog cancelDialog;

        private ProcedureType procedureType;
        private Physitian physitian;
        private DateTime selectedDate;
        private DateTime selectedTime;
        private bool urgency;
        private string notes;
        private Patient patient;

        private ObservableCollection<ProcedureType> procedureTypes;
        private ObservableCollection<Physitian> physitians;
        private ObservableCollection<DateTime> dates;
        private ObservableCollection<DateTime> times;

        private PhysitianScheduleController physitianScheduleController;
        private SpecialistAppointmentSchedulingController specialistAppointmentSchedulingController;

        private bool isNewDocument;
        private Visibility appointmentSchedulingMode;

        public int ProcedureType
        {
            get
            {
                for (int i = 0; i < procedureTypes.Count; i++)
                {
                    if (procedureType.Equals(procedureTypes[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                procedureType = procedureTypes[value];
                updateComboBoxes();
                RaisePropertyChanged("ProcedureType");
                RaisePropertyChanged("Physitians");
                RaisePropertyChanged("Dates");
                RaisePropertyChanged("Times");
            }
        }
        public int Physitian
        {
            get
            {
                if (physitian == null)
                {
                    return 0;
                }
                for (int i = 0; i < physitians.Count; i++)
                {
                    if (physitian.Equals(physitians[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                if (value >= 0 && value < physitians.Count)
                {
                    physitian = physitians[value];
                }
                else
                {
                    physitian = physitians[0];
                }

                RaisePropertyChanged("Physitian");
            }
        }

        public int SelectedDate
        {
            get
            {
                for (int i = 0; i < dates.Count; i++)
                {
                    if (selectedDate.Equals(dates[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                selectedDate = dates[value];
                RaisePropertyChanged("SelectedDate");
                //RaisePropertyChanged("Times");
            }
        }

        public int SelectedTime
        {
            get
            {
                for (int i = 0; i < times.Count; i++)
                {
                    if (selectedTime.Equals(times[i]))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                selectedTime = times[value];
                RaisePropertyChanged("SelectedTime");
            }
        }
        public bool Urgency { get => urgency; set => urgency = value; }
        public ObservableCollection<ProcedureType> ProcedureTypes
        {
            get
            {
                return procedureTypes;
            }
            set
            {
                procedureTypes = value;
                RaisePropertyChanged("ProcedureTypes");
            }
        }
        public ObservableCollection<Physitian> Physitians
        {
            get
            {
                return physitians;
            }
            set
            {
                physitians = value;
                RaisePropertyChanged("Physitians");
            }
        }
        public ObservableCollection<DateTime> Dates
        {
            get
            {
                return dates;
            }
            set
            {
                dates = value;
                RaisePropertyChanged("Dates");
            }
        }
        public ObservableCollection<DateTime> Times
        {
            get
            {
                ObservableCollection<DateTime> t = new ObservableCollection<DateTime>();
                foreach (DateTime time in times)
                {
                    if (time.Date.Equals(selectedDate.Date))
                    {
                        t.Add(time);
                    }
                }
                return t;
            }
            set
            {
                times = value;
                RaisePropertyChanged("Times");
            }
        }

        public string Notes { get => notes; set => notes = value; }

        public FollowUpViewModel(Patient patient)
        {
            IsNewDocument = true;
            AppointmentSchedulingMode = Visibility.Visible;
            this.patient = patient;
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianScheduleController = new PhysitianScheduleController(loggedPhysitian);
            specialistAppointmentSchedulingController = new SpecialistAppointmentSchedulingController();

            ProcedureType procedureType1 = new ProcedureType("pregled kod opste prakse", 30, new Specialization("opsta praksa"));
            ProcedureType procedureType2 = new ProcedureType("kardioloski pregled", 45, new Specialization("kardiologija"));
            ProcedureType procedureType3 = new ProcedureType("transplantacija kuka", 360, new Specialization("hirurgija"));
            ProcedureType procedureType4 = new ProcedureType("ultrazvuk abdomena", 60, new Specialization("interna medicina"));

            procedureTypes = new ObservableCollection<ProcedureType>();
            procedureTypes.Add(procedureType1);
            procedureTypes.Add(procedureType2);
            procedureTypes.Add(procedureType3);
            procedureTypes.Add(procedureType4);

            dates = new ObservableCollection<DateTime>();
            times = new ObservableCollection<DateTime>();
            physitians = new ObservableCollection<Physitian>();
            ProcedureType = 0;
            updateComboBoxes();

        }

        public FollowUpViewModel(FollowUp followUp)
        {
            IsNewDocument = false;
            AppointmentSchedulingMode = Visibility.Hidden;
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianScheduleController = new PhysitianScheduleController(loggedPhysitian);
            specialistAppointmentSchedulingController = new SpecialistAppointmentSchedulingController();

            ProcedureType procedureType1 = new ProcedureType("pregled kod opste prakse", 30, new Specialization("opsta praksa"));
            ProcedureType procedureType2 = new ProcedureType("kardioloski pregled", 45, new Specialization("kardiologija"));
            ProcedureType procedureType3 = new ProcedureType("transplantacija kuka", 360, new Specialization("hirurgija"));
            ProcedureType procedureType4 = new ProcedureType("ultrazvuk abdomena", 60, new Specialization("interna medicina"));

            procedureTypes = new ObservableCollection<ProcedureType>();
            procedureTypes.Add(procedureType1);
            procedureTypes.Add(procedureType2);
            procedureTypes.Add(procedureType3);
            procedureTypes.Add(procedureType4);

            this.notes = followUp.Notes;

            dates = new ObservableCollection<DateTime>();
            times = new ObservableCollection<DateTime>();
            physitians = new ObservableCollection<Physitian>();
            ProcedureType = 0;
            updateComboBoxes();
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
                        DateTime start = selectedDate.AddHours(selectedTime.Hour).AddMinutes(selectedTime.Minute);
                        DateTime end = start.AddMinutes(procedureType.EstimatedTimeInMinutes);
                        TimeInterval dateTime = new TimeInterval(start, end);
                        AppointmentDTO appointment = new AppointmentDTO { ProcedureType = procedureType, Physitian = physitian, Urgency = urgency, Time = dateTime };
                        //physitianScheduleController.NewAppointment(appointment);

                        //TODO: zakaciti uput na report
                        FollowUp followUp = new FollowUp(DateTime.Today, notes, physitian);
                        Messenger.Default.Send<AddDocumentMessage>(new AddDocumentMessage { document = followUp });
                    }
                    if (cancelDialog != null)
                    {
                        cancelDialog.Close();
                        Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "ReportView" });
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

        private void updateComboBoxes()
        {
            
        }
    }
}
