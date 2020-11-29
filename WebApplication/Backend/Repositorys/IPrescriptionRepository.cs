using Model.MedicalExam;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetPrescriptionsByProperty(string property, string value, string dateTimes, bool not);
    }
}
