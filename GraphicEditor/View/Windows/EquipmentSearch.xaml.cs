using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentSearch.xaml
    /// </summary>
    public partial class EquipmentSearch : Window
    {
        public EquipmentSearch()
        {
            this.DataContext = new EquipmentSearchViewModel();
            InitializeComponent();
        }
    }
}