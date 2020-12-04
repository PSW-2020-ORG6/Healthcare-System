using Backend.Repository;
using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using Model.Schedule;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    public class RoomAvailabilityService
    {
        private IAppointmentRepository appointmentRepository;
        private IRenovationRepository renovationRepository;
        private IBedReservationRepository bedReservationRepository;

        public RoomAvailabilityService()
        {
            this.appointmentRepository = new AppointmentFileSystem();
            this.renovationRepository = new RenovationFileSystem();
            this.bedReservationRepository = new BedReservationFileSystem();
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
            Console.WriteLine("" + HasAvailableBed(room) + " " + !IsRoomInRenovation(room, new TimeInterval(DateTime.Now, DateTime.Now)));
            return HasAvailableBed(room) && !IsRoomInRenovation(room, new TimeInterval(DateTime.Now, DateTime.Now));
        }
        public List<Bed> GetAvailableBeds(Room room)
        {
            List<Bed> beds = new List<Bed>();
            foreach (Bed bed in room.Beds)
            {
                beds.Add(bed);
                if(!IsBedReserved(bed))
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
            var bedReservations = bedReservationRepository.GetAll();
            return bedReservations.All(bedReservation => !bedReservation.Bed.Equals(bed));
        }
        private bool IsRoomInRenovation(Room room, TimeInterval timeInterval)
        {
            List<Renovation> renovations = renovationRepository.GetRenovationsByRoom(room);
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
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByRoom(room);
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
