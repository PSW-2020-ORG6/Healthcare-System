using GraphicEditor.HelpClasses;
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
        public List<EquipmentRelocation> EquipmentRelocations { get; set; }
        public MyICommand Relocate { get; private set; }
        
        public EquipmentRelocation SelectedER { get; set; }

        private EquipmentRelocationController EquipmentRelocationController = new EquipmentRelocationController();
        public EquipmentRelocationSuggestions(List<EquipmentRelocation> er)
        {
            this.DataContext = this;
            InitializeComponent();
            EquipmentRelocations = er;
            Relocate = new MyICommand(RelocateFunction);
        }

        private void RelocateFunction()
        {
            if (SelectedER != null)
            {
                EquipmentRelocationController.AddEquipmentRelocation(SelectedER);
                this.Close();
            }
        }
    }
}
