using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
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
    /// <summary>
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        public Appointment(MainWindowViewModel _viewModel)
        {
            this.DataContext = new AppointmentViewModel(_viewModel,this);
            InitializeComponent();
        }
    }
}
