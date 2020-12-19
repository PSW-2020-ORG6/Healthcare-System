using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class InpatientCareDatabaseSql: GenericDatabaseSql<InpatientCare>, IInpatientCareRepository
    {
        public InpatientCareDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }
        public List<InpatientCare> GetInpatientCaresForPatient(Patient patient)
        {
            throw new System.NotImplementedException();
        }
    }
}