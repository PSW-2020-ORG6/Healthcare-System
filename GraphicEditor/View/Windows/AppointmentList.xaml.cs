using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Dto;
using System.Collections.Generic;
using System.Windows;

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
