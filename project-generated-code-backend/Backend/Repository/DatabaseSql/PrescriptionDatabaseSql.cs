using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PrescriptionDatabaseSql : GenericDatabaseSql<Prescription>, IPrescriptionRepository
    {
        public override List<Prescription> GetAll()
        {
            return dbContext.Prescription
                .Include(p => p.MedicineDosage)
                .ToList();
        }
    }
}