using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class AppointmentDatabaseSql : GenericDatabaseSql<Appointment>, IAppointmentRepository
    {
        public override List<Appointment> GetAll()
        {
            return dbContext.Appointment.ToList();
        }

        public override Appointment GetById(string id)
        {
            return dbContext.Appointment.Find(id);
        }

        public override void Save(Appointment newEntity)
        {
            dbContext.Appointment.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Appointment updateEntity)
        {
            dbContext.Appointment.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var appointment = GetById(id);
            if (appointment == null) return;
            dbContext.Appointment.Remove(appointment);
            dbContext.SaveChanges();
        }

        public override Appointment GetBySerialNumber(string serialNumber)
        {
            return GetAll().Where(t => t.SerialNumber.Equals(serialNumber)).ToList()[0];
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
            return GetAll()
                .Where(appointment => (appointment.Patient.Id.Equals(patientId) ||
                                       appointment.Patient.SerialNumber.Equals(patientId)) &&
                                      !appointment.Active)
                .ToList();
        }
    }
}