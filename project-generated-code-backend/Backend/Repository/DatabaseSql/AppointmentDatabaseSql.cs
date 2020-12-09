using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class AppointmentDatabaseSql : GenericDatabaseSql<Appointment>,IAppointmentRepository
    {
        public override List<Appointment> GetAll()
        {
            return dbContext.Appointment
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