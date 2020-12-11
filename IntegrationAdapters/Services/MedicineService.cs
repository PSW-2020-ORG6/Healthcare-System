using IntegrationAdapters.Models;
using IntegrationAdapters.Models.DTO;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class MedicineService
    {
        private IMedicineRepository medicineRepository;

        public MedicineService()
        {
            this.medicineRepository = new MedicineRepository();
        }
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }
        public Medicine GetMedicineByID(String ID)
        {
            return medicineRepository.GetByID(ID);
        }
        public Medicine GetMedicineByName(String Name)
        {
            return medicineRepository.GetByName(Name);
        }
        public void AddMedicine()
        {
            medicineRepository.AddMedicineRepository();
        }
        
        private string GeneratePrescriptionString(PrescriptionDTO prescription)
        {
            string result = "";
            result += prescription.PatientName + " " + prescription.PatientSurName + "\n\n";
            result += prescription.Medicine + "\n";
            result += prescription.Quantity + "\n";
            result += prescription.PharmacyName + "\n";
            result += prescription.Note + "\n";
            return result;
        }

        public void GeneratePrescription(PrescriptionDTO prescription)
        {
            var fileName = GeneratePrescriptionFileName();
            System.IO.File.WriteAllText(fileName, string.Empty);
            TextWriter tw = new StreamWriter(fileName);
            
            tw.WriteLine(GeneratePrescriptionString(prescription));
            tw.Close();
        }

        public void GenerateSpecificationFromPharmacy(string responseText, string medicineName)
        {
            var fileName = GenerateSpecificationFileName(medicineName);
            System.IO.File.WriteAllText(fileName, string.Empty);
            
            TextWriter tw = new StreamWriter(fileName);
            
            tw.WriteLine(responseText);
            tw.Close();
        }

        public void GenerateSpecificationFromHospital(string medicineName)
        {
            var fileName = GenerateSpecificationFileName(medicineName);
            System.IO.File.WriteAllText(fileName, string.Empty);

            TextWriter tw = new StreamWriter(fileName);

            Medicine medicine = GetMedicineByName(medicineName);
            MedicineSpecification medicineSpecification = GetById(medicine.MedicineSpecificationID);

            tw.WriteLine(GenerateSpecificationString(medicineSpecification));
            tw.Close();
        }

        private string GenerateSpecificationString(MedicineSpecification medicineSpecification)
        {
            string result = "";
            result += "Producer: " + medicineSpecification.Producer + "\n";
            result += "Content: " + medicineSpecification.Content + "\n";
            result += "Notes: " + medicineSpecification.Notes + "\n";
            result += "Shape: " + medicineSpecification.Shape + "\n";
            return result;
        }


        private string GenerateSpecificationFileName(string medicineName)
        {
            return "Specification for " + medicineName + ".txt";
        }

        private string GeneratePrescriptionFileName()
        {
            return "Prescription " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
        }

        public Medicine DoesMedicineExist(string medicineName)
        {
            return GetMedicineByName(medicineName);
        }
       
    }
}
