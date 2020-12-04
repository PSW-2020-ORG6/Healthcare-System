﻿using Backend.Repository;
using Model.Accounts;
using Model.Schedule;
using Model.Util;
using System.Collections.Generic;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class PatientAvailabilityService
    {
        private IAppointmentRepository appointmentRepository;

        public PatientAvailabilityService()
        {
            this.appointmentRepository = new AppointmentFileSystem();
        }

        public bool IsPatientAvailable(Patient patient, TimeInterval timeInterval)
        {
            return !IsPatientScheduled(patient, timeInterval);
        }
        private bool IsPatientScheduled(Patient patient, TimeInterval timeInterval)
        {
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByPatient(patient);
            foreach (Appointment appointment in appointments)
            {
                if (timeInterval.IsOverLapping(appointment.TimeInterval))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
