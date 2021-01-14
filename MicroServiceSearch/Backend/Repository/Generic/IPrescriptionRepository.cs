using MicroServiceSearch.Backend.Model;
using System;
using System.Collections.Generic;

namespace MicroServiceSearch.Backend.Repository.Generic
{
    public interface IPrescriptionRepository: IGenericMsSearchRepository<Prescription>
    {
        List<Prescription> GetPrescriptionsBetweenDates(DateTime[] datetimes);
        List<Prescription> GetPrescriptionsBetweenDatesByMedicineName(DateTime[] dateTimes, string value);
        List<Prescription> GetPrescriptionsBetweenDatesByMedicineType(DateTime[] dateTimes, string medicineType);
        List<Prescription> GetPrescriptionsBetweenDatesByMedicineTypeNegation(DateTime[] dateTimes, string value);
        List<Prescription> GetPrescriptionsBetweenDatesByMedicineNameNegation(DateTime[] dateTimes, string value);
        List<Prescription> GetPrescriptionsBetweenDatesByAll(DateTime[] dateTimes, string value);
        List<Prescription> GetPrescriptionsBetweenDatesByAllNegation(DateTime[] dateTimes, string value);
    }
}