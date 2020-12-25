using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class EquipmentSearch : Window
    {
        public EquipmentSearch(MainWindowViewModel viewModel)
        {
            this.DataContext = new EquipmentSearchViewModel(viewModel);
            InitializeComponent();
        }
    }
}
