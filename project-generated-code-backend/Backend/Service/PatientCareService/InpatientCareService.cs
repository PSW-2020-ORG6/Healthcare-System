// File:    InpatientCareService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class InpatientCareService

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Service.PatientCareService
{
    public class InpatientCareService
    {
        private readonly Physician _loggedPhysician;
        private readonly IInpatientCareRepository _inpatientCareRepository;
        private readonly IBedReservationRepository _bedReservationRepository;
        private readonly IRoomRepository _roomRepository;

        public InpatientCareService(Physician loggedPhysician)
        {
            _loggedPhysician = loggedPhysician;
            _inpatientCareRepository = new InpatientCareDatabaseSql();
            _bedReservationRepository = new BedReservationDatabaseSql();
            _roomRepository = new RoomDatabaseSql();
        }

        public List<Room> GetAvailableRooms()
        {
            RoomAvailabilityService roomAvailabilityService = new RoomAvailabilityService();
            return GetAllRooms().Where(room => roomAvailabilityService.IsRoomAvailableForInpatientCare(room)).ToList();
        }

        public List<Bed> GetAvailableBeds(Room room)
        {
            RoomAvailabilityService roomAvailabilityService = new RoomAvailabilityService();
            return roomAvailabilityService.GetAvailableBeds(room);
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
            InpatientCare inpatientCare = new InpatientCare(dateOfAdmission, dateOfDischarge, _loggedPhysician, patient);
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