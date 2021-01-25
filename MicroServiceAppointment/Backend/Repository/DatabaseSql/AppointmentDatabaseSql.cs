using System;
using System.Collections.Generic;
using System.Linq;
using MicroServiceAccount.Backend.Model;
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class AppointmentDatabaseSql : GenericMsAppointmentDatabaseSql<Appointment>, IAppointmentRepository
    {
        public AppointmentDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Appointment> GetAll()
        {
            return DbContext.Appointment
                .Include(a => a.Patient)
                .Include(a => a.Physician)
                .Include(a => a.Room)
                .Include(a => a.ProcedureType)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return GetAll().Where(appointment => appointment.Date.Equals(date)).ToList();
        }
        public Appointment GetById(string id)
        {
            return GetAll().Where(p => p.SerialNumber.Equals(id)).ToList()[0];
        }
        public List<Appointment> GetAppointmentsByPatient(Patient patient)
        {
            return GetAll().Where(appointment => appointment.Patient.Equals(patient)).ToList();
        }

        public List<Appointment> GetAppointmentsByPhysician(Physician physician)
        {
            return GetAll().Where(appointment => appointment.Physician.Equals(physician)).ToList();
        }

        public List<Appointment> GetAppointmentsByRoom(Room room)
        {
            return GetAll().Where(appointment => appointment.Room.Equals(room)).ToList();
        }

        public List<Appointment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll().Where(appointment => appointment.Room.SerialNumber.Equals(roomSerialNumber)).ToList();
        }

        public List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber)
        {
            return GetAll().Where(appointment => appointment.Physician.SerialNumber.Equals(physicianSerialNumber)).ToList();
        }

        public List<Appointment> GetByPatientSerialNumber(string patientSerialNumber)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientSerialNumber)).ToList();
        }

        public List<Appointment> GetByPatientId(string patientId)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId)).ToList();
        }

        public List<Appointment> GetByPatientIdActive(string patientId)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId) && appointment.Active == true).ToList();
        }

        public List<Appointment> GetByPatientIdCanceled(string patientId)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId) && appointment.Active==false).ToList();
        }
        public List<Appointment> GetByPatientIdWithSurvey(string patientId)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId) && appointment.IsSurveyDone == true).ToList();
        }
        public List<Appointment> GetByPatientIdWithoutSurvey(string patientId)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId) && appointment.IsSurveyDone == false).ToList();
        }
        public List<String> GetByPatientIdCanceledDates(string patientId)
        {
            return GetByPatientIdCanceled(patientId).Select(a => a.DateOfCanceling).ToList();
        }

        public List<Appointment> IsSurveyDoneByPatientIdAppointmentDatePhysicianNameAppointments(string patientId, string appointmentDate, string id)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId) && appointment.Date.ToString().Equals(appointmentDate) && appointment.PhysicianSerialNumber.Equals(id)).ToList();
        }
        public override void Save(Appointment newEntity)
        {
            DbContext.Appointment.Add(newEntity);
            DbContext.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            DbContext.Appointment.Update(appointment);
            DbContext.SaveChanges();
        }
        public List<Appointment> GetDoneSurveyByPatentId(string patientId)
        {
            return GetByPatientId(patientId)
                   .Where(a => !a.IsSurveyDone)
                   .ToList();
        }

        public List<Appointment> GetAllAppointmentsByPatientIdDateAndDoctor(string patientId, DateTime date, string doctorName)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId) && appointment.PhysicianSerialNumber.Equals(doctorName)).ToList();
        }
    }
}