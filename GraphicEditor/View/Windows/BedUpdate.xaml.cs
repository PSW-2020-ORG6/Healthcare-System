using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class BedUpdate : Window
    {
        public BedUpdate(Bed bedInfo, DialogAnswerListener<Bed> bedUpdateAnswerListener)
        {
            this.DataContext = new BedUpdateViewModel(this, bedInfo, bedUpdateAnswerListener);
            InitializeComponent();
        }
    }
}
