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
            return DbContext.Appointment.ToList();
        }

        public override Appointment GetById(string id)
        {
            return DbContext.Appointment.Find(id);
        }

        public override void Save(Appointment newEntity)
        {
            DbContext.Appointment.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Appointment updateEntity)
        {
            DbContext.Appointment.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var appointment = GetById(id);
            if (appointment == null) return;
            DbContext.Appointment.Remove(appointment);
            DbContext.SaveChanges();
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
            return GetAll()
                .Where(appointment => appointment.Room.SerialNumber.Equals(roomSerialNumber))
                .ToList();
        }

        public List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber)
        {
            return GetAll()
                .Where(appointment => appointment.Physician.SerialNumber.Equals(physicianSerialNumber))
                .ToList();
        }

        public List<Appointment> GetByPatientSerialNumber(string patientSerialNumber)
        {
            return GetAll()
                .Where(appointment => appointment.Patient.SerialNumber.Equals(patientSerialNumber))
                .ToList();
        }

        public List<Appointment> GetByPatientId(string patientId)
        {
            return GetAll()
                .Where(appointment => appointment.Patient.Id.Equals(patientId))
                .ToList();
        }

        public List<Appointment> GetByPatientIdActive(string patientId)
        {
            return GetAll()
                .Where(appointment => (appointment.Patient.Id.Equals(patientId) ||
                                       appointment.Patient.SerialNumber.Equals(patientId)) &&
                                      appointment.Active)
                .ToList();
        }

        public List<Appointment> GetByPatientIdCanceled(string patientId)
        {
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patientId) && appointment.Active==false).ToList();
        }

        public List<DateTime> GetByPatientIdCanceledDates(string patientId)
        {
            return GetByPatientIdCanceled(patientId).Select(a => a.TimeInterval.Start).ToList();
        }
    }
}