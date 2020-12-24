using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Controller.SecretaryControllers;
using HealthClinicBackend.Backend.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for AppointmentList.xaml
    /// </summary>
    public partial class AppointmentList : Window
    {
        public AppointmentList(List<AppointmentDto> listOfAppointments, Window parent, MainWindowViewModel _viewModel)
        {
            this.DataContext = new AppointmentListViewModel(listOfAppointments, parent, _viewModel, this);
            InitializeComponent();
        }
    }
}
