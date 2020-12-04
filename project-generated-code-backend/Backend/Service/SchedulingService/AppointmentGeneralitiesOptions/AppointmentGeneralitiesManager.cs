using Backend.Dto;
using Backend.Repository;
using Model.Accounts;
using Model.Hospital;
using Model.Util;
using System.Collections.Generic;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class AppointmentGeneralitiesManager
    {
        private AppointmentDTO appointmentPreferrences;
        private IPhysitianRepository _iPhysitianRepository;
        private IRoomRepository roomRepository;

        public AppointmentGeneralitiesManager()
        {
            this._iPhysitianRepository = new IPhysitianFileSystem();
            this.roomRepository = new RoomFileSystem();
        }

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentPreferrences)
        {
            this.appointmentPreferrences = appointmentPreferrences;
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();

            List<TimeInterval> allTimeIntervals = GetAllTimeIntervals();
            List<Physician> allPhysitians = GetAllPhysitians();
            List<Room> allRooms = GetAllRooms();

            PhysitianAvailabilityService physitianAvailabilityService = new PhysitianAvailabilityService();
            RoomAvailabilityService roomAvailabilityService = new RoomAvailabilityService();

            foreach (TimeInterval timeInterval in allTimeIntervals)
            {
                foreach (Physician physitian in allPhysitians)
                {
                    if (physitianAvailabilityService.IsPhysitianAvailable(physitian, timeInterval))
                    {
                        foreach (Room room in allRooms)
                        {
                            if (roomAvailabilityService.IsRoomAvailable(room, timeInterval))
                            {
                                AppointmentDTO appointmentDTO = createAppointment(physitian, room, timeInterval);
                                appointments.Add(appointmentDTO);
                            }
                        }
                    }
                }
            }

            return appointments;
        }

        private AppointmentDTO createAppointment(Physician physician, Room room, TimeInterval timeInterval)
        {
            AppointmentDTO appointment = new AppointmentDTO();
            appointment.ProcedureType = appointmentPreferrences.ProcedureType;
            appointment.Patient = appointmentPreferrences.Patient;
            appointment.Time = timeInterval;
            appointment.Physician = physician;
            appointment.Room = room;
            return appointment;
        }
        private List<Physician> GetAllPhysitians()
        {
            List<Physician> physitians = new List<Physician>();
            if (appointmentPreferrences.IsPreferedPhysitianSelected())
            {
                physitians.Add(appointmentPreferrences.Physician);
            }
            else
            {
                physitians = _iPhysitianRepository.GetPhysitiansByProcedureType(appointmentPreferrences.ProcedureType);
            }
            return physitians;
        }
        private List<Room> GetAllRooms()
        {
            return roomRepository.GetRoomsByProcedureType(appointmentPreferrences.ProcedureType);
        }
        private List<TimeInterval> GetAllTimeIntervals()
        {
            TimeIntervalGenerator generator = new TimeIntervalGenerator(appointmentPreferrences.ProcedureType, appointmentPreferrences.RestrictedHours);
            List<TimeInterval> timeIntervals = new List<TimeInterval>();
            if (appointmentPreferrences.IsPreferredDateSelected())
            {
                timeIntervals = generator.generateTimeIntervalsForDay(appointmentPreferrences.Date);
            }
            else
            {
                timeIntervals = generator.generateAllTimeIntervals(); ;
            }
            return timeIntervals;
        }
    }
}
