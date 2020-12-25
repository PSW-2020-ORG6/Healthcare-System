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
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
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
        public Appointment()
        {
            InitializeComponent();
            this.DataContext = this;
            Physicians = physicianDatabaseSql.GetAll();
            Patients = patientDatabaseSql.GetAll();
            Rooms = roomDatabaseSql.GetAll();
            createTimeForDropBox();
            ComboBox.Items.Refresh();
            ComboBox2.Items.Refresh();

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
                if ((p.Name + " " + p.Surname).ToLower().Contains(PhysicianTextBox.Text.ToLower()))
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

        private void GetAllTermins(object sender, RoutedEventArgs e)
        {
            AppointmentDto appointmentDto = new AppointmentDto();
            //TODO set components here

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
            DateTime dateTime1 = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day
                , Int32.Parse(s[0]), Int32.Parse(s[1]), 0);

            DateTime dateTime2 = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day
                , Int32.Parse(s2[0]), Int32.Parse(s2[1]), 0);
            appointmentDto.Time = new TimeInterval(dateTime1, dateTime2);
            appointmentDto.Physician = selectedPhysician;
            appointmentDto.ProcedureType = new ProcedureType();
            appointmentDto.Patient = selectedPatient;
            appointmentDto.Active = true;
            /*TODO add this without causing errors
            appointmentDto.Room = selectedRoom;*/
            appointmentDto.Date = new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
            if (appointmentDto.Patient == null || appointmentDto.Physician == null)
            {
                MessageBox.Show("You did not select patient or physician");
                return;
            }
            /*TODO add this without causing errors
            if (appointmentDto.Room == null)
            {
                MessageBox.Show("You did not select room");
                return;
            }*/
            ProcedureType procType = new ProcedureType("Procedura", 30, new Specialization("Family doctor"));
            appointmentDto.ProcedureType = procType;
            List<AppointmentDto> appointmentDtos1 = secretaryScheduleController.GetAllAvailableAppointments(appointmentDto);
            List<AppointmentDto> result = new List<AppointmentDto>();
            foreach(AppointmentDto ap in appointmentDtos1)
            {
                if(ap.Time.Start >= appointmentDto.Time.Start && ap.Time.End <= appointmentDto.Time.End)
                {
                    ap.Date= new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
                    result.Add(ap);
                }
            }
            int a = 5;
            AppointmentList win = new AppointmentList(result);
            win.Show();
            /*TODO add this without causing errors
            List<AppointmentDto> appointmentDtos= secretaryScheduleController.MakeAppointment(appointmentDto,0);
            secretaryScheduleController.GetAllAvailableAppointments(appointmentDto);//call makeAppointment not getAllApp
            */
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
                if ((p.Name + " " + p.Surname).ToLower().Contains(PatientTextBox.Text.ToLower()))
                {
                    Patients.Add(p);
                    OnPropertyChanged();
                }
            }
            MyListBoxPatient.Items.Refresh();
        }
        /*TODO add this without causing errors
        private void FilterRooms(object sender, RoutedEventArgs e)
        {
            Rooms.Clear();
            foreach (Room r in roomDatabaseSql.GetAll())
            {
                if (r.Name.ToLower().Contains(RoomTextBox.Text.ToLower()))
                {
                    Rooms.Add(r);
                    OnPropertyChanged();
                }
            }
            MyListBoxRoom.Items.Refresh();
        }

        private void roomselectionchanged(object sender, selectionchangedeventargs e)
        {
            int index = mylistboxroom.selectedindex;
            selectedroom = rooms[index];
        }
        */
    }
}
