using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EquipmentRelocation = HealthClinicBackend.Backend.Model.Schedule.EquipmentRelocation;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentRelocationSuggestions.xaml
    /// </summary>
    public partial class EquipmentRelocationSuggestions : Window
    {
        
        public EquipmentRelocationSuggestions(List<EquipmentRelocation> er)
        {
            this.DataContext = new EquipmentRelocationSuggestionsViewModel(this, er);
            InitializeComponent();
        }

        
    }
}
