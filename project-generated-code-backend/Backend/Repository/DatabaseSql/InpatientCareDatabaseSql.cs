using System.Collections.Generic;
using Backend.Repository;
using Model.Accounts;
using Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class InpatientCareDatabaseSql: GenericDatabaseSql<InpatientCare>, IInpatientCareRepository
    {
        public List<InpatientCare> GetInpatientCaresForPatient(Patient patient)
        {
            throw new System.NotImplementedException();
        }
    }
}