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
        List<Prescription> GetPrescriptions(string sqlDml);
        List<MedicineDosage> GetMedicineDosage(string sqlDml);
        List<Prescription> GetPrescriptionsByProperty(string property, string value, string dateTimes, bool not);
    }
}
