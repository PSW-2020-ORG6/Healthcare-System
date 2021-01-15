using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class SchedulesWindow : Window
    {
        public SchedulesWindow()
        {
            this.DataContext = new SchedulesWindowViewModel(this);
            InitializeComponent();
        }
    }
}
