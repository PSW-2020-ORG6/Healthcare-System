using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SecretaryControllers;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    class EmergencyAppointmentViewModel : BindableBase
    {
        public List<ProcedureType> procedureTypes = new List<ProcedureType>();
        public List<Patient> patients = new List<Patient>();
        public event PropertyChangedEventHandler PropertyChanged;
        public PhysicianDatabaseSql physicianDatabaseSql = new PhysicianDatabaseSql();
        private ProcedureTypeDatabaseSql procedureTypeDatabaseSql = new ProcedureTypeDatabaseSql();
        public SecretaryScheduleController secretaryScheduleController = new SecretaryScheduleController();
        public PatientDatabaseSql patientDatabaseSql = new PatientDatabaseSql();
        public MainWindowViewModel _viewModel;
        public int patientIndex;
        public int procedureTypeIndex;
        public MyICommand<TextBox> FilterPatient { get; private set; }
        public MyICommand<object> ScheduleAppointment { get; private set; }

        public Window window;


        public List<ProcedureType> ProcedureTypes
        {
            get { return procedureTypes; }
            set
            {
                if (value != null)
                    SetProperty(ref procedureTypes, value);
            }
        }

        public int PatientIndex
        {
            get { return patientIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref patientIndex, value);
            }
        }

        public int ProcedureTypeIndex
        {
            get { return procedureTypeIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref procedureTypeIndex, value);
            }
        }

        public List<Patient> Patients
        {
            get { return patients; }
            set
            {
                if (value != null)
                    SetProperty(ref patients, value);
            }
        }

        public EmergencyAppointmentViewModel(MainWindowViewModel _viewModel, Window window)
        {
            //Should here be controller calls?
            Patients = patientDatabaseSql.GetAll();
            ProcedureTypes = procedureTypeDatabaseSql.GetAll();
            this._viewModel = _viewModel;
            this.window = window;
            FilterPatient = new MyICommand<TextBox>(FilterPatientMethod);
            ScheduleAppointment = new MyICommand<object>(EmergencyScheduleResult);
        }

        private void EmergencyScheduleResult(Object obj)
        {
            AppointmentDto appointmentDto = new AppointmentDto();

            appointmentDto.Patient = Patients[patientIndex];
            appointmentDto.Active = true;
            if (appointmentDto.Patient == null)
            {
                MessageBox.Show("You did not select patient");
                return;
            }
            appointmentDto.ProcedureType = procedureTypes[procedureTypeIndex];
            appointmentDto.Date = DateTime.Now;
            DateTime endTime = DateTime.Now;
            endTime = endTime.AddHours(2.0);    // one hour is emergency interval to find available appointment
            appointmentDto.Time = new TimeInterval(DateTime.Now, endTime);

            AppointmentDto scheduledAppointment = secretaryScheduleController.GetEmergencyAppointmentGEA(appointmentDto);

            if ( scheduledAppointment != null)
            {
                EmergencyScheduleResult emergencyScheduleResult = new EmergencyScheduleResult(scheduledAppointment, window);
                emergencyScheduleResult.Show();
            }
            else
            {
                //analysis
            }

        }

        private void FilterPatientMethod(TextBox textBox)
        {
            Patients.Clear();
            List<Patient> patientsPom = new List<Patient>();
            foreach (Patient p in patientDatabaseSql.GetAll())
            {
                if ((p.Name + " " + p.Surname).ToLower().Contains(textBox.Text.ToLower()))
                {
                    patientsPom.Add(p);
                }
            }
            Patients = patientsPom;
        }
    }
}
