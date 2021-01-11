using IntegrationAdapters.Models;
using IntegrationAdapters.Models.DTO;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
        public void AddMedicine()
        {
            medicineRepository.AddMedicineRepository();
        }

        public MedicineSpecification GetById(string id)
        {
            foreach (MedicineSpecification ms in GetAllSpecifications())
            {
                if (ms.ID.Equals(id))
                {
                    return ms;
                }

            }
            return null;
            
        }
        public List<MedicineSpecification> GetAllSpecifications()
        {
            return medicineRepository.GetAllSpecifications();
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
            SftpService sftpService = new SftpService();
            var fileName = GeneratePrescriptionFileName();
            System.IO.File.WriteAllText(fileName, string.Empty);
            TextWriter tw = new StreamWriter(fileName);       
            tw.WriteLine(GeneratePrescriptionString(prescription));
            tw.Close();
            sftpService.SendFile(fileName);
            MedicineReportService medicineReportService = new MedicineReportService();
            medicineReportService.SendNotificationAboutReport(fileName);
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

        public void GenerateSpecificationFromHospital(string medicineName)
        {
            var fileName = GenerateSpecificationFileName(medicineName);
            System.IO.File.WriteAllText(fileName, string.Empty);

            TextWriter tw = new StreamWriter(fileName);

            Medicine medicine = GetMedicineByName(medicineName);
            MedicineSpecification medicineSpecification = GetById(medicine.MedicineSpecificationID);

            tw.WriteLine(GenerateSpecificationString(medicineSpecification));
            tw.Close();
            Process.Start("notepad.exe", fileName);

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
