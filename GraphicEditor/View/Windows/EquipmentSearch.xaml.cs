using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentSearch.xaml
    /// </summary>
    public partial class EquipmentSearch : Window
    {
        public EquipmentSearch(MainWindowViewModel viewModel)
        {
            this.DataContext = new EquipmentSearchViewModel(viewModel);
            InitializeComponent();
        }
    }
}