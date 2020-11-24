using Model.Hospital;
using Model.MedicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public interface IPrescriptionRepository
    {
        public List<Prescription> GetAll();
        public List<Prescription> GetPrescriptions(string sqlDml);
        public List<MedicineDosage> GetMedicineDosage(string sqlDml);
        public Medicine GetMedicine(string sqlDml);
        public string GetMedicineType(string sqlDml);
        public List<Prescription> GetPrescriptionsByProperty(string property, string value, bool not);
    }
}
