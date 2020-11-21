using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : UserControl
    {
        public PatientView()
        {
            InitializeComponent();
        }

        private void CollapsePatientBtn_Click(object sender, RoutedEventArgs e)
        {
            CollapsePatientBtn.Visibility = Visibility.Hidden;
            ExpandPatientBtn.Visibility = Visibility.Visible;
        }

        private void ExpandPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpandPatientBtn.Visibility = Visibility.Hidden;
            CollapsePatientBtn.Visibility = Visibility.Visible;
        }

        private void patientDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            patientTableScrollViewer.ScrollToVerticalOffset(patientTableScrollViewer.VerticalOffset - e.Delta);
        }

    }
}
