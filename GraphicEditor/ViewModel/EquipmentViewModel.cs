using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicEditor.ViewModel
{
    public class EquipmentViewModel: BindableBase
    {
        List<Equipment> listOfEquipments = new List<Equipment>();
        private EquipmentDatabaseSql equipmentDatabaseSql = new EquipmentDatabaseSql();
        public EquipmentViewModel(string roomSerialNumber)
        {
            ListOfEquipments = equipmentDatabaseSql.GetAll().Where(r => r.RoomId.Equals(roomSerialNumber)).ToList();
        }

        public List<Equipment> ListOfEquipments
        {
            get { return listOfEquipments; }
            set
            {
                if (value != null)
                    SetProperty(ref listOfEquipments, value);
            }
        }
    }
}
