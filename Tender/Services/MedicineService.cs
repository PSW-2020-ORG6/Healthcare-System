using TenderProcurement.Models;
using TenderProcurement.Models.DTO;
using TenderProcurement.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenderProcurement.Services
{
    public class MedicineService
    {
        private IMedicineRepository medicineRepository;

        public MedicineService()
        {
            this.medicineRepository = new MedicineRepository();
        }
        public MedicineService(IMedicineRepository imedicineRepository)
        {
            this.medicineRepository = imedicineRepository;
        }
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }

	public bool AddMedicineUrgently(Medicine medicine, int quantity)
        {
            Medicine med = GetMedicineByName(medicine.Name);
            if (med != null) 
            {
                med.Quantity += quantity;
                medicineRepository.SaveChanges();
            } 
            else
            {
                medicineRepository.AddMedicine(medicine);
                
            }
            return true;
        }

        public bool AddMedicineFromTender(string medicineName, int quantity)
        {
            Medicine med = GetMedicineByName(medicineName);
            if (med != null)
            {
                med.Quantity += quantity;
                medicineRepository.SaveChanges();
            }
            else
            {
                medicineRepository.AddMedicine(new Medicine(Guid.NewGuid().ToString("N"),medicineName,null,quantity));

            }
            return true;
        }


        public Medicine GetByID(string ID)
        {
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.MedicineID.Equals(ID)) return medicine;
            }
            return null;
        }
        public Medicine GetMedicineByName(String Name)
        {
            return medicineRepository.GetByName(Name);
        }

        public void GenerateSpecificationFromPharmacy(string responseText, string medicineName)
        {
            var fileName = GenerateSpecificationFileName(medicineName);
            System.IO.File.WriteAllText(fileName, string.Empty);
            
            TextWriter tw = new StreamWriter(fileName);
            
            tw.WriteLine(responseText);
            tw.Close();
            Process.Start("notepad.exe", fileName);
        }

        public bool DoesMedicineExist(Medicine medicine)
        {
            return medicineRepository.DoesMedicineExist(medicine);
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
