using GraphicEditor.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
