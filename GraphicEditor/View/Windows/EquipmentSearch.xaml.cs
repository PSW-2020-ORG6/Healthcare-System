using System.Collections.Generic;
using System.Windows;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentSearch.xaml
    /// </summary>
    public partial class EquipmentSearch : Window
    {
        private IEquipmentRepository equipmentRepository = new EquipmentDatabaseSql();
        private IRoomRepository roomRepository = new RoomDatabaseSql();
        private IMedicineRepository medicineRepository = new MedicineDatabaseSql();

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

        private void GenerateReport(string itemName, List<Equipment> equipments, List<Medicine> medicines)
        {
            if (equipments == null)
            {
                equipments = new List<Equipment>();
            }

            if (medicines == null)
            {
                medicines = new List<Medicine>();
            }

            if (equipments.Count != 0)
                SearchEquipmentTextBlock.Text = ReportOnFoundEqipment(itemName, equipments);
            else if (medicines.Count != 0)
                //TODO  ReportOnFoundMedicine(itemName, medicines);
                SearchEquipmentTextBlock.Text = "";
            else
                SearchEquipmentTextBlock.Text = "There is no such item.";
        }

        private string ReportOnFoundMedicine(string medicineName, Medicine medicine)
        {
            string resultOfSearch = "";
            int equipmentCounter = 1;

            if (equipmentCounter != 0)
            {
                int checkCounter = 0;
                resultOfSearch += checkCounter + 1 + "\n";
                resultOfSearch += "\n" + "Generic name: " + medicine.GenericName +
                                  " MedicineManufacturerSerialNumber: " + medicine.MedicineManufacturer.SerialNumber +
                                  " MedicineTypeSerialNumber: " + medicine.MedicineType.SerialNumber +
                                  " SerialNumber: " + medicine.SerialNumber;
                if (++checkCounter == equipmentCounter)
                    return resultOfSearch += ".";
                else
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
                    Room room = roomRepository.GetById(equipment.RoomId);
                    resultOfSearch += "\nInformation about rooms: ";
                    //TODO resultOfSearch += RoomSearch.ReportOnFoundRooms(equipment.RoomId, room);
                    if (++checkCounter == equipmentCounter)
                        return resultOfSearch += ".";
                    else
                        resultOfSearch += ",";
                }
            }

            return null;
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            new EquipmentSearch().Show();
        }
    }
}