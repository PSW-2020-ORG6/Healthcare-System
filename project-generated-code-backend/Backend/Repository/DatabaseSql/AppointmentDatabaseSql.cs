using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
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
    }
}