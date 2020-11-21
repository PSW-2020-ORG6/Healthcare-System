using Model.Accounts;
using Model.MedicalExam;
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
    /// Interaction logic for SpecialistReferralView.xaml
    /// </summary>
    public partial class SpecialistReferralView : UserControl
    {
        public SpecialistReferralView()
        {
            InitializeComponent();
        }

        private void specialistRefferalNotes_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            notesScrollViewer.ScrollToVerticalOffset(notesScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
