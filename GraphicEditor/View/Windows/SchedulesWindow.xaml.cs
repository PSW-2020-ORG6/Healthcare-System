﻿using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class SchedulesWindow : Window
    {
        public SchedulesWindow(List<Appointment> appointments, List<EquipmentRelocation> equipmentRelocations,
             List<RoomRenovation> renovations)
        {
            this.DataContext = new SchedulesWindowViewModel(appointments, equipmentRelocations, renovations, this);
            InitializeComponent();
        }
    }
}
