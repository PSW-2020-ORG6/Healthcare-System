using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SecretaryControllers;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window, INotifyPropertyChanged
    {
        public List<Physician> physicians = new List<Physician>();
        public List<Patient> patients = new List<Patient>();
        public List<Room> rooms = new List<Room>();
        public event PropertyChangedEventHandler PropertyChanged;
        public PhysicianDatabaseSql physicianDatabaseSql = new PhysicianDatabaseSql();
        public Physician selectedPhysician;
        public Patient selectedPatient;
        public Room selectedRoom;
        public List<string> myTime = new List<string>();
        public SecretaryScheduleController secretaryScheduleController = new SecretaryScheduleController();
        public PatientDatabaseSql patientDatabaseSql = new PatientDatabaseSql();
        public RoomDatabaseSql roomDatabaseSql = new RoomDatabaseSql();
        MainWindowViewModel _viewModel;
        public List<Physician> Physicians
        {
            get { return physicians; }
            set
            {
                physicians = value;
                OnPropertyChanged();
            }
        }

        public List<Patient> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                OnPropertyChanged();
            }
        }

        public List<Room> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                OnPropertyChanged();
            }
        }
        public List<string> MyTime
        {
            get { return myTime; }
            set
            {
                myTime = value;
                OnPropertyChanged();
            }
        }
        public Appointment(MainWindowViewModel _viewModel)
        {
            InitializeComponent();
            this.DataContext = this;
            Physicians = physicianDatabaseSql.GetAll();
            Patients = patientDatabaseSql.GetAll();
            Rooms = roomDatabaseSql.GetAll();
            createTimeForDropBox();
            ComboBox.Items.Refresh();
            ComboBox2.Items.Refresh();
            doctorPriority.IsChecked = true;
            this._viewModel = _viewModel;

        }

        private void createTimeForDropBox()
        {
            for (int i = 0; i < 24; i++)
            {
                MyTime.Add(i.ToString() + ":" + "00");
                MyTime.Add(i.ToString() + ":" + "30");
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void FilterPhysician(object sender, RoutedEventArgs e)
        {
            Physicians.Clear();
            foreach (Physician p in physicianDatabaseSql.GetAll())
            {
                if (p.FullName.ToLower().Contains(PhysicianTextBox.Text.ToLower()))
                {
                    Physicians.Add(p);
                    OnPropertyChanged();
                }
            }
            MyListBox.Items.Refresh();

        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MyListBox.SelectedIndex;
            selectedPhysician = Physicians[index];
        }

        private void DisplayPossibleAppointments(object sender, RoutedEventArgs e)
        {
            AppointmentDto appointmentDto = new AppointmentDto();

            string[] s = ComboBox.Text.Split(":");
            string[] s2 = ComboBox2.Text.Split(":");
            if (s.Length != 2 || s2.Length != 2)
            {
                MessageBox.Show("You did not select time from or time to");
                return;
            }
            DateTime? dateTime = Date.SelectedDate;
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
            if (DateTime.Now> dateTime)
            {
                MessageBox.Show("You can not select date in past !!!");
                return;
            }
            DateTime dateTime1 = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day
                , hours, min, 0);

            DateTime dateTime2 = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day
                , hours2, min2, 0);
            appointmentDto.Time = new TimeInterval(dateTime1, dateTime2);
            appointmentDto.Physician = selectedPhysician;
            appointmentDto.ProcedureType = new ProcedureType();
            appointmentDto.Patient = selectedPatient;
            appointmentDto.Active = true;
            appointmentDto.Date = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
            if (appointmentDto.Patient == null || appointmentDto.Physician == null)
            {
                MessageBox.Show("You did not select patient or physician");
                return;
            }
            ProcedureType procType = new ProcedureType("Procedura", 30, new Specialization("Family doctor"));
            appointmentDto.ProcedureType = procType;
            int priority=doctorPriority.IsChecked== true ? 0:1;
            List<AppointmentDto> appointmentDtos1 = secretaryScheduleController.GetAllAvailableAppointmentsGEA(appointmentDto, priority);
            
            AppointmentList win = new AppointmentList(appointmentDtos1, this, _viewModel);
            win.Show();
        }

        private void PatientsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MyListBoxPatient.SelectedIndex;
            selectedPatient = Patients[index];
        }

        private void FilterPatient(object sender, RoutedEventArgs e)
        {
            Patients.Clear();
            foreach (Patient p in patientDatabaseSql.GetAll())
            {
                if (p.FullName.ToLower().Contains(PatientTextBox.Text.ToLower()))
                {
                    Patients.Add(p);
                    OnPropertyChanged();
                }
            }
            MyListBoxPatient.Items.Refresh();
        }

        //private void FilterRooms(object sender, RoutedEventArgs e)
        //{
        //    Rooms.Clear();
        //    foreach (Room r in roomDatabaseSql.GetAll())
        //    {
        //        if (r.Name.ToLower().Contains(RoomTextBox.Text.ToLower()))
        //        {
        //            Rooms.Add(r);
        //            OnPropertyChanged();
        //        }
        //    }
        //    MyListBoxRoom.Items.Refresh();
        //}

        //private void RoomSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int index = MyListBoxRoom.SelectedIndex;
        //    selectedRoom = Rooms[index];
        //}
    }
}
