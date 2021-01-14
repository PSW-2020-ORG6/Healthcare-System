using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class AppointmentDatabaseSql : GenericDatabaseSql<Appointment>, IAppointmentRepository
    {
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
            return GetAll().Where(appointment => appointment.PatientSerialNumber.Equals(patient)).ToList();
        }

        public List<Appointment> GetAppointmentsByPhysician(Physician physician)
        {
            return GetAll().Where(appointment => appointment.PhysicianSerialNumber.Equals(physician.SerialNumber)).ToList();
        }

        public List<Appointment> GetAppointmentsByRoom(Room room)
        {
            return GetAll().Where(appointment => appointment.RoomSerialNumber.Equals(room.SerialNumber)).ToList();
        }

        public List<Appointment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll()
                .Where(appointment => appointment.RoomSerialNumber.Equals(roomSerialNumber))
                .ToList();
        }

        public List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber)
        {
            return GetAll()
                .Where(appointment => appointment.PhysicianSerialNumber.Equals(physicianSerialNumber))
                .ToList();
        }

        public List<Appointment> GetByPatientSerialNumber(string patientSerialNumber)
        {
            return GetAll()
                .Where(appointment => appointment.PatientSerialNumber.Equals(patientSerialNumber))
                .ToList();
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
            throw new NotImplementedException();
        }
    }
}