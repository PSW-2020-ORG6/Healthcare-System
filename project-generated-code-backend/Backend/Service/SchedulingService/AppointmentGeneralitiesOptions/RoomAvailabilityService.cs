using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    public class RoomAvailabilityService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IRenovationRepository _renovationRepository;
        private readonly IBedReservationRepository _bedReservationRepository;

        public RoomAvailabilityService(IAppointmentRepository appointmentRepository,
            IRenovationRepository renovationRepository, IBedReservationRepository bedReservationRepository)
        {
            _appointmentRepository = appointmentRepository;
            _renovationRepository = renovationRepository;
            _bedReservationRepository = bedReservationRepository;
        }

        public bool IsRoomAvailableAtAnyTime(Room room, List<TimeInterval> timeIntervals)
        {
            foreach (TimeInterval timeInterval in timeIntervals)
            {
                if (IsRoomAvailable(room, timeInterval))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsAnyRoomAvailable(List<Room> rooms, TimeInterval timeInterval)
        {
            foreach (Room room in rooms)
            {
                if (IsRoomAvailable(room, timeInterval))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsRoomAvailable(Room room, TimeInterval timeInterval)
        {
            return !IsRoomScheduled(room, timeInterval) && !IsRoomInRenovation(room, timeInterval);
        }

        public bool IsRoomAvailableForInpatientCare(Room room)
        {
            return HasAvailableBed(room) && !IsRoomInRenovation(room, new TimeInterval(DateTime.Now, DateTime.Now));
        }

        public List<Bed> GetAvailableBeds(Room room)
        {
            List<Bed> beds = new List<Bed>();
            foreach (Bed bed in room.Beds)
            {
                beds.Add(bed);
                if (!IsBedReserved(bed))
                {
                    beds.Add(bed);
                }
            }

            return beds;
        }

        private bool HasAvailableBed(Room room)
        {
            return room.Beds.Any(bed => !IsBedReserved(bed));
        }

        private bool IsBedReserved(Bed bed)
        {
            var bedReservations = _bedReservationRepository.GetAll();
            return bedReservations.All(bedReservation => !bedReservation.Bed.Equals(bed));
        }

        private bool IsRoomInRenovation(Room room, TimeInterval timeInterval)
        {
            List<Renovation> renovations = _renovationRepository.GetRenovationsByRoom(room);
            foreach (Renovation renovation in renovations)
            {
                if (timeInterval.IsOverLapping(renovation.TimeInterval))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsRoomScheduled(Room room, TimeInterval timeInterval)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByRoom(room);
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