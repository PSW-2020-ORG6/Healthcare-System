using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for MedicineSearch.xaml
    /// </summary>
    public partial class MedicineSearch : Window
    {
        public MedicineSearch(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = new MedicineSearchViewModel(viewModel);
        }
    }
}
