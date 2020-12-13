using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentSearch.xaml
    /// </summary>
    public partial class EquipmentSearch : Window
    {
        private EquipmentDatabaseSql equipmentRepository = new EquipmentDatabaseSql();
        private RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        private MedicineDatabaseSql medicineRepository = new MedicineDatabaseSql();
        private FloorDatabaseSql floorRepository = new FloorDatabaseSql();
        private BuildingDatabaseSql buildingRepository = new BuildingDatabaseSql();

        public EquipmentSearch()
        {
            InitializeComponent();
        }

        private void SearchEquipmentOrMedicine(object sender, RoutedEventArgs e)
        {
            string itemName = EquipmentNameTextBox.Text;

            List<Equipment> equipments = equipmentRepository.GetByName(itemName);
            List<Medicine> medicines = medicineRepository.GetByName(itemName);

            GenerateReport(itemName, equipments, medicines);
            EquipmentNameTextBox.Text = null;
        }

        private void GenerateReport(string itemName, List<Equipment> equipments, List<Medicine> medicine)
        {
            if (equipments == null)
            {
                equipments = new List<Equipment>();
            }
            if (medicine == null)
            {
                medicine = new List<Medicine>();
            }
            if (equipments.Count != 0)
                SearchEquipmentTextBlock.Text = ReportOnFoundEqipment(itemName, equipments);
            else if (medicine.Count != 0)
                SearchEquipmentTextBlock.Text = ReportOnFoundMedicine(itemName, medicine);
            else
                SearchEquipmentTextBlock.Text = "There is no such item.";
        }

        private string ReportOnFoundMedicine(string medicineName, List<Medicine> medicine)
        {
            string resultOfSearch = "";
            int equipmentCounter = 1;

            if (equipmentCounter != 0)
            {
                int checkCounter = 0;
                resultOfSearch += checkCounter + 1 + "\n";
                foreach (Medicine m in medicine)
                    // TODO
                   // resultOfSearch += "\n" + "Generic name: " + m.GenericName + " MedicineManufacturerSerialNumber: " 
                     //   + m.MedicineManufacturer.SerialNumber + " MedicineTypeSerialNumber: " 
                      //  + m.MedicineType.SerialNumber + " SerialNumber: " + m.SerialNumber;
                if (++checkCounter == equipmentCounter)
                    return resultOfSearch += ".";
                resultOfSearch += ",";

            }
            return null;
        }

        private string ReportOnFoundEqipment(string equipmentName, List<Equipment> equipments)
        {
            string resultOfSearch = equipmentName + " found at: ";
            int equipmentCounter = equipments.Count;

            if (equipmentCounter != 0)
            {
                int checkCounter = 0;
                foreach (Equipment equipment in equipments)
                {
                    Room room = roomRepository.GetBySerialNumber(equipment.RoomId);
                    resultOfSearch += "\nInformation about rooms: ";
                    resultOfSearch += room.Name + " ";
                    resultOfSearch = PlaceOfFoundRooms(resultOfSearch, room);
                    if (++checkCounter == equipmentCounter)
                        return resultOfSearch += ".";
                    else
                        resultOfSearch += ",";
                }
            }
            return null;
        }
        private string PlaceOfFoundRooms(string resultOfSearch, Room room)
        {
            Floor floor = floorRepository.GetBySerialNumber(room.FloorSerialNumber);
            Building building = buildingRepository.GetBySerialNumber(floor.BuildingSerialNumber);
            resultOfSearch += floor.Name + " in " + building.Name;
            return resultOfSearch;
        }
    }
}
