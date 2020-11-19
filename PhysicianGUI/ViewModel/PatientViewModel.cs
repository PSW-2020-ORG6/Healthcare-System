using Backend.Controller.PhysitianControllers;
using Model.Accounts;
using Model.Schedule;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.FrontendAdapters;
using HealthClinic.Message;
using HealthClinic.util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using health_clinic_class_diagram.Backend.Controller.PhysitianControllers;

namespace HealthClinic.ViewModel
{
    class PatientViewModel : ViewModelBase
    {
        private bool _dataGridRowIsSelected;
        private ObservableCollection<PatientAdapter> allPatients;
        private ObservableCollection<PatientAdapter> patients;

        private PhysitianHospitalController physitianHospitalController;
        private PhysitianScheduleController physitianScheduleController;
        private PhysitianHospitalAccountsController physitianHospitalAccountsController;

        private PatientAdapter selectedPatient;
        private String searchQuery;

        public bool DataGridRowIsSelected
        {
            get
            {
                return selectedPatient != null;
            }
        }

        public ObservableCollection<PatientAdapter> Patients
        {
            get
            {
                return patients;
            }
            set
            {
                patients = value;
                RaisePropertyChanged("Patients");
            }
        }

        public PatientAdapter SelectedPatient
        {
            get
            {
                return selectedPatient;
            }
            set
            {
                selectedPatient = value;
                RaisePropertyChanged("SelectedPatient");
                RaisePropertyChanged("DataGridRowIsSelected");
            }
        }

        public PatientViewModel()
        {
            Physitian loggedPhysitian = (Physitian)Application.Current.Properties["LoggedPhysitian"];
            physitianHospitalController = new PhysitianHospitalController();
            physitianScheduleController = new PhysitianScheduleController(loggedPhysitian);
            physitianHospitalAccountsController = new PhysitianHospitalAccountsController(loggedPhysitian);

            List<Patient> patientList = physitianHospitalAccountsController.GetPatientsByPhysitian();
            allPatients = new ObservableCollection<PatientAdapter>();

            foreach(Patient p in patientList)
            {
                Appointment nextAppointment = physitianHospitalAccountsController.GetNextAppointmentForPatient(p);
                Appointment previousAppointment = physitianHospitalAccountsController.GetPreviousAppointmentForPatient(p);
                PatientAdapter patient = new PatientAdapter(p, previousAppointment, nextAppointment);
                allPatients.Add(patient);
            }

            patients = allPatients;
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

        public ICommand ChangeToPatientDetailViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<ViewPatientInfoMessage>(new ViewPatientInfoMessage { Patient = selectedPatient.Patient });
                });
            }
        }

        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }
            set
            {
                searchQuery = value;
                Patients = searchPatients();
            }
        }

        private ObservableCollection<PatientAdapter> searchPatients()
        {
            ObservableCollection<PatientAdapter> retVal = new ObservableCollection<PatientAdapter>();

            foreach(PatientAdapter p in allPatients)
            {
                if(p.FullName.ToLower().Contains(searchQuery.ToLower()) && !retVal.Contains(p))
                {
                    retVal.Add(p);
                }

                if(p.Patient.Id.Contains(searchQuery) && !retVal.Contains(p))
                {
                    retVal.Add(p);
                }
            }

            return retVal;
        }
    }
}
