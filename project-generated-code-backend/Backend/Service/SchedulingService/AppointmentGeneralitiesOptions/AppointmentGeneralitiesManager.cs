using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class AppointmentGeneralitiesManager
    {
        private AppointmentDto _appointmentPreferences;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly PhysicianAvailabilityService _physicianAvailabilityService;
        private readonly RoomAvailabilityService _roomAvailabilityService;

        public AppointmentGeneralitiesManager(IPhysicianRepository physicianRepository,
            IRoomRepository roomRepository,
            IAppointmentRepository appointmentRepository,
            IRenovationRepository renovationRepository,
            IBedReservationRepository bedReservationRepository)
        {
            _physicianRepository = physicianRepository;
            _roomRepository = roomRepository;
            _physicianAvailabilityService = new PhysicianAvailabilityService(appointmentRepository);
            _roomAvailabilityService =
                new RoomAvailabilityService(appointmentRepository, renovationRepository, bedReservationRepository);
        }

        public List<AppointmentDto> GetAllAvailableAppointments(AppointmentDto appointmentPreferences)
        {
            _appointmentPreferences = appointmentPreferences;
            List<AppointmentDto> appointments = new List<AppointmentDto>();

            List<TimeInterval> allTimeIntervals = GetAllTimeIntervals();

            List<Physician> allPhysicians = GetAllPhysicians();
            List<Room> allRooms = GetAllRooms();

            foreach (TimeInterval timeInterval in allTimeIntervals)
            {
                foreach (Physician physician in allPhysicians)
                {
                    if (_physicianAvailabilityService.IsPhysicianAvailable(physician, timeInterval))
                    {
                        foreach (Room room in allRooms)
                        {
                            if (_roomAvailabilityService.IsRoomAvailable(room, timeInterval))
                            {
                                AppointmentDto appointmentDto = CreateAppointment(physician, room, timeInterval);
                                appointments.Add(appointmentDto);
                            }
                        }
                    }
                }
            }

            return appointments;
        }


        /***
         * Authors Peki and Hadzi
         * Returns all available appointments, regarding needed equipment, available room and available patient for one day.
         */
        public List<AppointmentDto> GetAllAvailableAppointmentsGEA(AppointmentDto appointmentPreferences, ref bool noDoctors)
        {
            _appointmentPreferences = appointmentPreferences;
            List<AppointmentDto> appointments = new List<AppointmentDto>();

            List<TimeInterval> allTimeIntervals = GetAllTimeIntervalsGEA(); //free appointments for chosen time interval

            List<Physician> allPhysicians = GetAllPhysiciansGEA(ref noDoctors);
            List<Room> allRooms = GetAllRoomsGEA();

            foreach (TimeInterval timeInterval in allTimeIntervals)
            {
                foreach (Physician physician in allPhysicians)
                {
                    if (_physicianAvailabilityService.IsPhysicianAvailable(physician, timeInterval))
                    {
                        foreach (Room room in allRooms)
                        {
                            if (_roomAvailabilityService.IsRoomAvailable(room, timeInterval))
                            {
                                AppointmentDto appointmentDto = CreateAppointment(physician, room, timeInterval);
                                appointments.Add(appointmentDto);
                            }
                        }
                    }
                }
            }

            return appointments;
        }

        private AppointmentDto CreateAppointment(Physician physician, Room room, TimeInterval timeInterval)
        {
            AppointmentDto appointment = new AppointmentDto();
            appointment.ProcedureType = _appointmentPreferences.ProcedureType;
            appointment.Patient = _appointmentPreferences.Patient;
            appointment.Time = timeInterval;
            appointment.Physician = physician;
            appointment.Room = room;
            return appointment;
        }

        private List<Physician> GetAllPhysicians()
        {
            List<Physician> physicians = new List<Physician>();
            if (_appointmentPreferences.IsPreferedPhysicianSelected())
            {
                physicians.Add(_appointmentPreferences.Physician);
            }
            else
            {
                physicians = _physicianRepository.GetByProcedureType(_appointmentPreferences.ProcedureType);
            }

            return physicians;
        }

        private List<Physician> GetAllPhysiciansGEA(ref bool noDoctors)
        {
            List<Physician> physicians = new List<Physician>();
            if (_appointmentPreferences.IsPreferedPhysicianSelected())
            {
                Physician physician = _physicianRepository.GetById(_appointmentPreferences.Physician.SerialNumber);
                if (physician.Specialization.Contains(_appointmentPreferences.ProcedureType.Specialization))
                {
                    physicians.Add(_appointmentPreferences.Physician);
                }
                else
                {
                    physicians = _physicianRepository.GetByProcedureType(_appointmentPreferences.ProcedureType);
                    if (physicians == null || physicians.Count == 0)
                    {
                        noDoctors = true;
                    }
                }
            }
            else
            {
                physicians = _physicianRepository.GetByProcedureType(_appointmentPreferences.ProcedureType);
            }
            return physicians;
        }

        private List<Room> GetAllRooms()
        {
            return _roomRepository.GetAll();
            //return _roomRepository.GetByProcedureType(_appointmentPreferences.ProcedureType);
        }

        private List<Room> GetAllRoomsGEA()
        {
            return _roomRepository.GetByProcedureType(_appointmentPreferences.ProcedureType);
        }


        /***
         * This method determines time intervals 
         */
        private List<TimeInterval> GetAllTimeIntervalsGEA()
        {
            TimeIntervalGenerator generator = new TimeIntervalGenerator(_appointmentPreferences.ProcedureType,
                _appointmentPreferences.RestrictedHours);
            List<TimeInterval> timeIntervals = new List<TimeInterval>();
            List<TimeInterval> generatedTimeIntervals = generator.GenerateTimeIntervalsForDay(_appointmentPreferences.Date);
            foreach (TimeInterval timeInterval in generatedTimeIntervals)
            {
                if (timeInterval.Start >= _appointmentPreferences.Time.Start && timeInterval.End <= _appointmentPreferences.Time.End)
                {
                    timeIntervals.Add(timeInterval);
                }
            }
            return timeIntervals;
        }

        /***
         * This method determines date intervals
         * */
        private List<TimeInterval> GetAllTimeIntervals()
        {
            TimeIntervalGenerator generator = new TimeIntervalGenerator(_appointmentPreferences.ProcedureType,
                _appointmentPreferences.RestrictedHours);
            List<TimeInterval> timeIntervals;
            if (_appointmentPreferences.IsPreferredDateSelected())
            {
                timeIntervals = generator.GenerateTimeIntervalsForDay(_appointmentPreferences.Date);
            }
            else
            {
                timeIntervals = generator.GenerateAllTimeIntervals();
            }

            return timeIntervals;
        }


    }
}