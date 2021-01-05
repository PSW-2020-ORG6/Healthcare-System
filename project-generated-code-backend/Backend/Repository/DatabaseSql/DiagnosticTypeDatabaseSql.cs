using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class DiagnosticTypeDatabaseSql : GenericDatabaseSql<DiagnosticType>, IDiagnosticTypeRepository
    {
        public DiagnosticTypeDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<DiagnosticType> GetAll()
        {
            return DbContext.DiagnosticType.ToList();
        }
    }
}