using Model.MedicalExam;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.util;
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
using System.Windows.Shapes;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for AddedDocumentsDialog.xaml
    /// </summary>
    public partial class AddedDocumentsDialog : Window
    {
        public AddedDocumentsDialog()
        {
            InitializeComponent();
        }

        private void documentsDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            documentsTableScrollViewer.ScrollToVerticalOffset(documentsTableScrollViewer.VerticalOffset - e.Delta);
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
