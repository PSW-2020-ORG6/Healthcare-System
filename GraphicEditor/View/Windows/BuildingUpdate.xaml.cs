using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using health_clinic_class_diagram.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for BuildingUpdate.xaml
    /// </summary>
    public partial class BuildingUpdate : Window
    {
        public BuildingUpdate(Building building, DialogAnswerListener<Building> dialogAnswerListener)
        {
            this.DataContext = new BuildingUpdateViewModel(this, building, dialogAnswerListener);
            InitializeComponent();
        }
    }
}
