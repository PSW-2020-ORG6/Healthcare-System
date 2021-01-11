using HealthClinicBackend.Backend.Model.MedicalExam;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IPrescriptionRepository : IGenericRepository<Prescription>
    {
        List<Prescription> GetPrescriptionsBetweenDates(DateTime[] datetimes);
    }
}