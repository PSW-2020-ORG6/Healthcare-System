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
            var fileName = "Prescription " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            System.IO.File.WriteAllText(fileName, string.Empty);
            TextWriter tw = new StreamWriter(fileName);
            
            tw.WriteLine(GeneratePrescriptionString(prescription));
            tw.Close();
        }

        public void GenerateSpecification(string result, string MedicineName)
        {
            var fileName = "Specification for " + MedicineName + ".txt";
            System.IO.File.WriteAllText(fileName, string.Empty);
            
            TextWriter tw = new StreamWriter(fileName);
            
            tw.WriteLine(result);
            tw.Close();
        }
    }
}
