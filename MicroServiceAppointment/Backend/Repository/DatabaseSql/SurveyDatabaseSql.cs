using MicroServiceAppointment.Backend.Model.Survey;
using MicroServiceAppointment.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class SurveyDatabaseSql : GenericMsAppointmentDatabaseSql<Survey>, ISurveyRepository
    {
        public SurveyDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
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