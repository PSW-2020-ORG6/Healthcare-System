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
    /// Interaction logic for InpatientCareHistoryDialog.xaml
    /// </summary>
    public partial class InpatientCareHistoryDialog : Window
    {
        public InpatientCareHistoryDialog()
        {
            InitializeComponent();
        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            inpatientHistoryScrollViewer.ScrollToVerticalOffset(inpatientHistoryScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
