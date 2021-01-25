﻿using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class PatientAvailabilityService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public PatientAvailabilityService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public bool IsPatientAvailable(Patient patient, TimeInterval timeInterval)
        {
            return !IsPatientScheduled(patient, timeInterval);
        }

        private bool IsPatientScheduled(Patient patient, TimeInterval timeInterval)
        {
            List<Appointment> appointments = _appointmentRepository.GetByPatientSerialNumber(patient.SerialNumber);
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