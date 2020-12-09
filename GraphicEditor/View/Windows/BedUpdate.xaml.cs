using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using System.Windows;
using HealthClinicBackend.Backend.Model.Hospital;

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
