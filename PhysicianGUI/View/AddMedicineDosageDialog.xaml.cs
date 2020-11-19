using Model.MedicalExam;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.ViewModel;
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
    /// Interaction logic for AddMedicineDosageDialog.xaml
    /// </summary>
    public partial class AddMedicineDosageDialog : Window
    {
        public AddMedicineDosageDialog()
        {
            InitializeComponent();
        }

        private void SubmitMedicineDosageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelMedicineDosageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void notesRichTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            notesScrollViewer.ScrollToVerticalOffset(notesScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
