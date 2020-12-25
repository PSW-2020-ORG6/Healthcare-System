using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class MedicineSearch : Window
    {
        public MedicineSearch(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = new MedicineSearchViewModel(viewModel);
        }
    }
}
