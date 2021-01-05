// File:    InpatientCareService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class InpatientCareService

using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;

namespace HealthClinicBackend.Backend.Service.PatientCareService
{
    public class InpatientCareService
    {
        private readonly Physician _loggedPhysician;
        private readonly IInpatientCareRepository _inpatientCareRepository;
        private readonly IBedReservationRepository _bedReservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly RoomAvailabilityService _roomAvailabilityService;

        public InpatientCareService(Physician loggedPhysician, IInpatientCareRepository inpatientCareRepository,
            IBedReservationRepository bedReservationRepository, IRoomRepository roomRepository,
            IAppointmentRepository appointmentRepository, IRenovationRepository renovationRepository)
        {
            _loggedPhysician = loggedPhysician;
            _inpatientCareRepository = inpatientCareRepository;
            _bedReservationRepository = bedReservationRepository;
            _roomRepository = roomRepository;
            _roomAvailabilityService =
                new RoomAvailabilityService(appointmentRepository, renovationRepository, bedReservationRepository);
        }

        public List<Room> GetAvailableRooms()
        {
            return GetAllRooms().Where(room => _roomAvailabilityService.IsRoomAvailableForInpatientCare(room)).ToList();
        }

        public List<Bed> GetAvailableBeds(Room room)
        {
            return _roomAvailabilityService.GetAvailableBeds(room);
        }

        public void StartInpatientCare(BedReservationDto bedReservationDto)
        {
            _bedReservationRepository.Save(new BedReservation(bedReservationDto));
        }

        public void DischargePatient(Patient patient)
        {
            BedReservation activeBedReservation = _bedReservationRepository.GetBedReservationByPatient(patient);
            _bedReservationRepository.Delete(activeBedReservation.SerialNumber);
            DateTime dateOfAdmission = activeBedReservation.TimeInterval.Start;
            DateTime dateOfDischarge = DateTime.Now;
            InpatientCare inpatientCare =
                new InpatientCare(dateOfAdmission, dateOfDischarge, _loggedPhysician, patient);
            _inpatientCareRepository.Save(inpatientCare);
        }

        public BedReservation GetActiveBedReservation(Patient patient)
        {
            return _bedReservationRepository.GetBedReservationByPatient(patient);
        }

        public List<InpatientCare> GetAllInpatientCares(Patient patient)
        {
            return _inpatientCareRepository.GetInpatientCaresForPatient(patient);
        }

        private List<Room> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }
    }
}