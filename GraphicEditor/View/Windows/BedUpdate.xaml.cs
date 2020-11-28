using GraphicEditor.ViewModel;
using Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for BedUpdate.xaml
    /// </summary>
    public partial class BedUpdate : Window
    {
        public BedUpdate(Bed BedInfo)
        {
            this.DataContext = new BedUpdateViewModel(this, BedInfo);
            InitializeComponent();
        }
    }
}
