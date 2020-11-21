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
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void findings_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            findingsScrollViewer.ScrollToVerticalOffset(findingsScrollViewer.VerticalOffset - e.Delta);
        }

        private void conditionsRichTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            conditionsScrollViewer.ScrollToVerticalOffset(conditionsScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
