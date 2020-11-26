using GraphicEditor.HelpClasses;
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
        public BedUpdate(Bed bedInfo, DialogAnswerListener<Bed> bedUpdateAnswerListener)
        {
            this.DataContext = new BedUpdateViewModel(this, bedInfo, bedUpdateAnswerListener);
            InitializeComponent();
        }
    }
}
