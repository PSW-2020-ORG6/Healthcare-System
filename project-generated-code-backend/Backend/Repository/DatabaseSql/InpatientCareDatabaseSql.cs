using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class InpatientCareDatabaseSql : GenericDatabaseSql<InpatientCare>, IInpatientCareRepository
    {
        public List<InpatientCare> GetInpatientCaresForPatient(Patient patient)
        {
            throw new System.NotImplementedException();
        }
    }
}