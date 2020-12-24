using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SecretaryControllers;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    public class AppointmentViewModel : BindableBase
    {
        public List<Physician> physicians = new List<Physician>();
        public List<Patient> patients = new List<Patient>();
        public List<Room> rooms = new List<Room>();
        public event PropertyChangedEventHandler PropertyChanged;
        public PhysicianDatabaseSql physicianDatabaseSql = new PhysicianDatabaseSql();
        public Room selectedRoom;
        public List<string> myTime = new List<string>();
        public SecretaryScheduleController secretaryScheduleController = new SecretaryScheduleController();
        public PatientDatabaseSql patientDatabaseSql = new PatientDatabaseSql();
        public RoomDatabaseSql roomDatabaseSql = new RoomDatabaseSql();
        public MainWindowViewModel _viewModel;
        public int physiciansIndex;
        public int patientIndex;
        public DateTime datePicker=DateTime.Now;
        public MyICommand<TextBox> FilterPhysician { get; private set; }
        public MyICommand<TextBox> FilterPatient { get; private set; }
        public MyICommand<object> ShowTermins { get; private set; }
        public int fromTimeIndex;
        public int toTimeIndex;
        public bool isCheckedDoctorPriority=true;
        public bool isCheckedTerminPriority=false;
        public Window window;

        public bool IsCheckedDoctorPriority
        {
            get { return isCheckedDoctorPriority; }
            set
            {
                if (value != null)
                    SetProperty(ref isCheckedDoctorPriority, value);
            }
        }
        public bool IsCheckedTerminPriority
        {
            get { return isCheckedTerminPriority; }
            set
            {
                if (value != null)
                    SetProperty(ref isCheckedTerminPriority, value);
            }
        }
        public int FromTime
        {
            get { return fromTimeIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref fromTimeIndex, value);
            }
        }
        public int ToTime
        {
            get { return toTimeIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref toTimeIndex, value);
            }
        }
        public List<Physician> Physicians
        {
            get { return physicians; }
            set
            {
                if (value != null)
                    SetProperty(ref physicians, value);
            }
        }

        public DateTime DatePicker
        {
            get { return datePicker; }
            set
            {
                if (value != null)
                    SetProperty(ref datePicker, value);
            }
        }

        public int PhysiciansIndex
        {
            get { return physiciansIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref physiciansIndex, value);
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
        public List<Patient> Patients
        {
            get { return patients; }
            set
            {
                if (value != null)
                    SetProperty(ref patients, value);
            }
        }
        public List<Room> Rooms
        {
            get { return rooms; }
            set
            {
                if (value != null)
                    SetProperty(ref rooms, value);
            }
        }
        public List<string> MyTime
        {
            get { return myTime; }
            set
            {
                if (value != null)
                    SetProperty(ref myTime, value);
            }
        }
        public AppointmentViewModel(MainWindowViewModel _viewModel,Window window)
        {
            Physicians = physicianDatabaseSql.GetAll();
            Patients = patientDatabaseSql.GetAll();
            Rooms = roomDatabaseSql.GetAll();
            createTimeForDropBox();
            this._viewModel = _viewModel;
            this.window = window;
            FilterPhysician = new MyICommand<TextBox>(FilterPhysicianMethod);
            FilterPatient = new MyICommand<TextBox>(FilterPatientMethod);
            ShowTermins = new MyICommand<object>(DisplayPossibleAppointments);
        }

        private void DisplayPossibleAppointments(Object obj)
        {
           AppointmentDto appointmentDto = new AppointmentDto();
            
            string[] s = myTime[fromTimeIndex].Split(":");
            string[] s2 = myTime[toTimeIndex].Split(":");
            if (s.Length != 2 || s2.Length != 2)
            {
                MessageBox.Show("You did not select time from or time to");
                return;
            }
            DateTime? dateTime = DatePicker;
            if (dateTime == null)
            {
                MessageBox.Show("You did not select date from date picker");
                return;
            }
            int hours = Int32.Parse(s[0]);
            int min = Int32.Parse(s[1]);
            int hours2 = Int32.Parse(s2[0]);
            int min2 = Int32.Parse(s2[1]);
            if (hours > hours2 || (hours == hours2 && min > min2))
            {
                MessageBox.Show("Time FROM must be less then TO !!!");
                return;
            }
            if (DateTime.Now > dateTime)
            {
                MessageBox.Show("You can not select date in past !!!");
                return;
            }
            DateTime dateTime1 = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day
                , hours, min, 0);

            DateTime dateTime2 = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day
                , hours2, min2, 0);
            appointmentDto.Time = new TimeInterval(dateTime1, dateTime2);
            appointmentDto.Physician = Physicians[physiciansIndex];
            appointmentDto.ProcedureType = new ProcedureType();
            appointmentDto.Patient = Patients[patientIndex];
            appointmentDto.Active = true;
            appointmentDto.Date = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
            if (appointmentDto.Patient == null || appointmentDto.Physician == null)
            {
                MessageBox.Show("You did not select patient or physician");
                return;
            }
            ProcedureType procType = new ProcedureType("Procedura", 30, new Specialization("Family doctor"));
            appointmentDto.ProcedureType = procType;
            int priority = isCheckedDoctorPriority == true ? 0 : 1;
            List<AppointmentDto> appointmentDtos1 = secretaryScheduleController.GetAllAvailableAppointmentsGEA(appointmentDto, priority);

            AppointmentList win = new AppointmentList(appointmentDtos1, window, _viewModel);
            win.Show();
        }

        private void FilterPhysicianMethod(TextBox textBox)
        {
            Physicians.Clear();
            List<Physician> physiciansPom = new List<Physician>();
            foreach (Physician p in physicianDatabaseSql.GetAll())
            {
                if ((p.Name + " " + p.Surname).ToLower().Contains(textBox.Text.ToLower()))
                {
                    physiciansPom.Add(p);
                }
            }
            Physicians = physiciansPom;
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

        private void createTimeForDropBox()
        {
            for (int i = 0; i < 24; i++)
            {
                MyTime.Add(i.ToString() + ":" + "00");
                MyTime.Add(i.ToString() + ":" + "30");
            }
        }
    }
}
