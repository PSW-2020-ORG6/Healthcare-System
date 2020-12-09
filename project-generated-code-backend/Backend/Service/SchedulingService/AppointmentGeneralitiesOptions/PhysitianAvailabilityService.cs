using Backend.Repository;
using Model.Accounts;
using Model.Schedule;
using Model.Util;
using System.Collections.Generic;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    public class PhysitianAvailabilityService
    {
        private IAppointmentRepository appointmentRepository;

        public PhysitianAvailabilityService()
        {
            this.appointmentRepository = new AppointmentFileSystem();
        }

        public bool IsPhysitianAvailableAtAnyTime(Physician physician, List<TimeInterval> timeIntervals)
        {
            foreach (TimeInterval timeInterval in timeIntervals)
            {
                if (IsPhysitianAvailable(physician, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsAnyPhysitianAvailable(List<Physician> physitians, TimeInterval timeInterval)
        {
            foreach (Physician physitian in physitians)
            {
                if (IsPhysitianAvailable(physitian, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsPhysitianAvailable(Physician physician, TimeInterval timeInterval)
        {
            bool isTheirShift = physician.IsTheirShift(timeInterval);
            bool isNotOnVacation = !physician.IsOnVacation(timeInterval);
            bool isNotScheduled = !IsPhysitianScheduled(physician, timeInterval);
            return isTheirShift && isNotOnVacation && isNotScheduled;
        }
        public bool canGoOnVacation(Physician physician, TimeInterval timeInterval)
        {
            bool isNotOnVacation = !physician.IsOnVacation(timeInterval);
            bool isNotScheduled = !IsPhysitianScheduled(physician, timeInterval);
            return isNotOnVacation && isNotScheduled;
        }

        private bool IsPhysitianScheduled(Physician physician, TimeInterval timeInterval)
        {
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByPhysician(physician);
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
