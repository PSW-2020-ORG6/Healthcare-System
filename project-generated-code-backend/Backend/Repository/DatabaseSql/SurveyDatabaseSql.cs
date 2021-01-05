using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Survey;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SurveyDatabaseSql : GenericDatabaseSql<Survey>, ISurveyRepository
    {
        public SurveyDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Survey> GetAll()
        {
            return DbContext.Survey.ToList();
        }

        public override void Save(Survey newEntity)
        {
            DbContext.Survey.Add(newEntity);
            DbContext.SaveChanges();
        }

        public List<Survey> GetByPatientId(string patientId)
        {
            return GetAll().Where(s => s.PatientId.Equals(patientId)).ToList();
        }

        public List<string> GetDoctorNamesByPatientId(string patientId)
        {
            return GetAll().Where(s => s.PatientId.Equals(patientId)).Select(s => s.DoctorName).ToList();
        }

        public List<Survey> GetByDoctorName(string doctorName)
        {
            return GetAll().Where(s => s.DoctorName.Equals(doctorName)).ToList();
        }
    }
}