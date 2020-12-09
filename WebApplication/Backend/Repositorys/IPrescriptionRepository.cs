using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace WebApplication.Backend.Repositorys
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetPrescriptionsByProperty(SearchProperty property, string value, string dateTimes, bool not);
    }
}
