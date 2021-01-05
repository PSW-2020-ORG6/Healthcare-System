using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class AppointmentDatabaseSql : GenericDatabaseSql<Appointment>, IAppointmentRepository
    {
        public AppointmentDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
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
            throw new NotImplementedException();
        }

        public List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetByPatientSerialNumber(string patientSerialNumber)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetByPatientId(string patientId)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetByPatientIdActive(string patientId)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetByPatientIdCanceled(string patientId)
        {
            throw new NotImplementedException();
        }

        public List<DateTime> GetByPatientIdCanceledDates(string patientId)
        {
            return GetByPatientIdCanceled(patientId).Select(a => a.TimeInterval.Start).ToList();
        }
    }
}