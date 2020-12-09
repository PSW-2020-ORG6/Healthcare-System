using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class DiagnosticTypeDatabaseSql: GenericDatabaseSql<DiagnosticType>, IDiagnosticTypeRepository
    {
        public override List<DiagnosticType> GetAll()
        {
            return dbContext.DiagnosticType.ToList();
        }
    }
}