using MicroServiceSearch.Backend.Model;
using System;
using System.Collections.Generic;

namespace MicroServiceSearch.Backend.Repository.Generic
{
    public interface IPrescriptionRepository: IGenericMsSearchRepository<Prescription>
    {
        List<Prescription> GetPrescriptionsBetweenDates(DateTime[] datetimes);
    }
}