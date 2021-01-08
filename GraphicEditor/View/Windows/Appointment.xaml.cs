using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        public Appointment(MainWindowViewModel _viewModel)
        {
            this.DataContext = new AppointmentViewModel(_viewModel, this);
            InitializeComponent();
        }
    }
}
