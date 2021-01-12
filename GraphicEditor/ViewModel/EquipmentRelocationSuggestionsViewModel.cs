using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class EquipmentRelocationSuggestionsViewModel : BindableBase
    {
        public List<EquipmentRelocation> EquipmentRelocations
        {
            get => equipmentRelocations;
            set
            {

                SetProperty(ref equipmentRelocations, value);
            }
        }
        public MyICommand Relocate { get; private set; }

        public EquipmentRelocation SelectedER { get; set; }

        private EquipmentRelocationController EquipmentRelocationController = new EquipmentRelocationController();
        private List<EquipmentRelocation> equipmentRelocations;
        private Window parent;

        public EquipmentRelocationSuggestionsViewModel(Window _parent, List<EquipmentRelocation> er)
        {
            equipmentRelocations = er;
            Relocate = new MyICommand(RelocateFunction);
            parent = _parent;
        }

        private void RelocateFunction()
        {
            if (SelectedER != null)
            {
                EquipmentRelocationController.AddEquipmentRelocation(SelectedER);
                parent.Close();
            }
        }
    }
}
