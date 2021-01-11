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
        private ProcedureTypeDatabaseSql procedureTypeDatabaseSql = new ProcedureTypeDatabaseSql();
        private PatientDatabaseSql patientDatabaseSql = new PatientDatabaseSql();
        private PhysicianDatabaseSql physicianDatabaseSql = new PhysicianDatabaseSql();
        private RoomDatabaseSql roomDatabaseSql = new RoomDatabaseSql();
        public override List<Appointment> GetAll()
        {
            List<Appointment> appointments = DbContext.Appointment.ToList(); //this gets only staticly added appointments? Do we need to write sql query?

            List<ProcedureType> procedureTypes = DbContext.ProcedureType.ToList();

            foreach( var appointment in appointments )
            {
                appointment.ProcedureType = procedureTypes.Where(pt => pt.SerialNumber.Equals(appointment.ProcedureTypeSerialnumber)).ToList()[0];
                appointment.Patient = patientDatabaseSql.GetById(appointment.PatientSerialNumber);
                appointment.Physician = physicianDatabaseSql.GetById(appointment.PhysicianSerialNumber);
                appointment.Room = roomDatabaseSql.GetById(appointment.RoomSerialNumber);
            }


            return appointments;
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
            return GetAll().Where(appointment => appointment.Patient.Equals(patient)).ToList();
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
            return GetAll().Where(appointment => (appointment.Patient.Id.Equals(patientId) ||
                                       appointment.Patient.SerialNumber.Equals(patientId)) &&
                                      !appointment.Active).ToList();
        }

        public List<DateTime> GetByPatientIdCanceledDates(string patientId)
        {
            return GetByPatientIdCanceled(patientId).Select(a => a.TimeInterval.Start).ToList();
        }
    }
}