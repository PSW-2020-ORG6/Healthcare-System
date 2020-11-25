using System.Windows;
using System.Windows.Controls;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for MedicineTableView.xaml
    /// </summary>
    public partial class MedicineTableView : UserControl
    {
        public static int selectedRadio;
        public delegate void medicineVoidDelegate();
        public static event medicineVoidDelegate setAllDelegatesToNull;
        public MedicineTableView()
        {
            setAllDelegatesToNull();
            selectedRadio = 0;
            InitializeComponent();
            Tables.Content = new WaitingMedicinePage();
        }

        private void waiting_Chacked(object sender, RoutedEventArgs e)
        {
            setAllDelegatesToNull();
            medicineHeader.Content = "Lekovi na čekanju:";
            selectedRadio = 0;
            if (Tables != null)
                Tables.Content = new WaitingMedicinePage();
        }

        private void rejected_Chacked(object sender, RoutedEventArgs e)
        {
            setAllDelegatesToNull();
            medicineHeader.Content = "Odbijeni lekovi:";
            selectedRadio = 1;
            if (Tables != null)
                Tables.Content = new RejectedMedicineTablePage();
        }

        private void approval_Chacked(object sender, RoutedEventArgs e)
        {
            setAllDelegatesToNull();
            medicineHeader.Content = "Odobreni lekovi:";
            selectedRadio = 2;
            if (Tables != null)
                Tables.Content = new ApprovedMedicineTablePage();
        }
    }
}
