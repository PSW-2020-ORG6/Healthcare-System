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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for PatientDetailView.xaml
    /// </summary>
    public partial class PatientDetailView : UserControl
    {
        public PatientDetailView()
        {
            InitializeComponent();
        }

        private void reportsDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            reportsTableScrollViewer.ScrollToVerticalOffset(reportsTableScrollViewer.VerticalOffset - e.Delta);
        }

        private void conditionsRichTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            conditionsScrollViewer.ScrollToVerticalOffset(conditionsScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
