using GraphicEditor.ViewModel;
using System.Collections.Generic;
using System.Windows;
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
