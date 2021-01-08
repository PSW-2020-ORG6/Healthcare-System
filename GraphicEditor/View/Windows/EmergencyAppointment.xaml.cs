using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EmergencyAppointment.xaml
    /// </summary>
    public partial class EmergencyAppointment : Window
    {
        public EmergencyAppointment(MainWindowViewModel _viewModel)
        {
            this.DataContext = new EmergencyAppointmentViewModel(_viewModel, this);
            InitializeComponent();
        }
    }
}
