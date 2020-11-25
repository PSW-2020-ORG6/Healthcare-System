using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for MedicineView.xaml
    /// </summary>
    public partial class MedicineView : UserControl
    {
        public MedicineView()
        {
            InitializeComponent();
        }

        private void CollapseMedicineBtn_Click(object sender, RoutedEventArgs e)
        {
            CollapseMedicineBtn.Visibility = Visibility.Hidden;
            ExpandMedicineBtn.Visibility = Visibility.Visible;
        }

        private void ExpandMedicineBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpandMedicineBtn.Visibility = Visibility.Hidden;
            CollapseMedicineBtn.Visibility = Visibility.Visible;
        }

        private void medicineDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            medicineTableScrollViewer.ScrollToVerticalOffset(medicineTableScrollViewer.VerticalOffset - e.Delta);
        }

        private void medicineDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isRowSelected;
            if (medicineDataGrid.SelectedItem == null)
            {
                isRowSelected = false;
            }
            else
            {
                isRowSelected = true;
            }
            Messenger.Default.Send<DataGridSelectionChangedMessage>(new DataGridSelectionChangedMessage { dataGridRowIsSelected = isRowSelected });
        }
    }
}
