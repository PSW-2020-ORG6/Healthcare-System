using GraphicEditor.Repositories;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
using System.Collections.Generic;
using System.Windows;
using EquipmentRepository = GraphicEditor.Repositories.EquipmentRepository;
using RoomRepository = GraphicEditor.Repositories.RoomRepository;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentSearch.xaml
    /// </summary>
    public partial class EquipmentSearch : Window
    {
        private EquipmentRepository equipmentRepository = new EquipmentRepository();
        private RoomRepository roomRepository = new RoomRepository();
        private MedicineRepository medicineRepository = new MedicineRepository();

        public EquipmentSearch()
        {
            InitializeComponent();
        }

        private void SearchEquipmentOrMedicine(object sender, RoutedEventArgs e)
        {
            string itemName = EquipmentNameTextBox.Text;

            List<Equipment> equipments = equipmentRepository.GetEquipmentsByName(itemName);
            List<MedicineGEA> medicines = medicineRepository.GetMedicinesByName(itemName);

            GenerateReport(itemName, equipments, medicines);
            EquipmentNameTextBox.Text = null;
        }

        private void GenerateReport(string itemName, List<Equipment> equipments, List<MedicineGEA> medicines)
        {
            if (equipments == null)
            {
                equipments = new List<Equipment>();
            }
            if (medicines == null)
            {
                medicines = new List<MedicineGEA>();
            }
            if (equipments.Count != 0)
                SearchEquipmentTextBlock.Text = ReportOnFoundEqipment(itemName, equipments);
            else if (medicines.Count != 0)
                SearchEquipmentTextBlock.Text = ReportOnFoundMedicine(itemName, medicines);
            else
                SearchEquipmentTextBlock.Text = "There is no such item.";
        }

        private string ReportOnFoundMedicine(string medicineName, List<MedicineGEA> medicines)
        {
            string resultOfSearch = "";
            int equipmentCounter = medicines.Count;

            if (equipmentCounter != 0)
            {
                int checkCounter = 0;
                foreach (MedicineGEA medicine in medicines)
                {
                    resultOfSearch += checkCounter + 1 + "\n";
                    resultOfSearch += "\n" + "Generic name: " + medicine.GenericName + " MedicineManufacturerId: " + medicine.MedicineManufacturerId + " MedicineTypeId: " + medicine.MedicineTypeId + " SerialNumber: " + medicine.SerialNumber;
                    if (++checkCounter == equipmentCounter)
                        return resultOfSearch += ".";
                    else
                        resultOfSearch += ",";
                }
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
                    List<RoomGEA> rooms = roomRepository.GetRoomsBySerialNumber(equipment.RoomId);
                    resultOfSearch += "\nInformation about rooms: ";
                    resultOfSearch += RoomSearch.ReportOnFoundRooms(equipment.RoomId, rooms);
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
