// File:    InpatientCareController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class InpatientCareController

using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Service.PatientCareService;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class InpatientCareController
    {
        private Physician LoggedPhysician;
        private readonly InpatientCareService _inpatientCareService;

        public InpatientCareController(InpatientCareService inpatientCareService)
        {
            _inpatientCareService = inpatientCareService;
        }

        public void StartInpatientCare(BedReservationDto bedReservationDTO)
        {
            _inpatientCareService.StartInpatientCare(bedReservationDTO);
        }

        public void DischargePatient(Patient patient)
        {
            _inpatientCareService.DischargePatient(patient);
        }

        public BedReservation GetActiveInpatientCare(Patient patient)
        {
            return _inpatientCareService.GetActiveBedReservation(patient);
        }

        public List<InpatientCare> GetPreviousInpatientCares(Patient patient)
        {
            return _inpatientCareService.GetAllInpatientCares(patient);
        }

        public List<Room> GetAvailableRooms()
        {
            return _inpatientCareService.GetAvailableRooms();
        }

        public List<Bed> GetAvailableBeds(Room room)
        {
            return _inpatientCareService.GetAvailableBeds(room);
        }
    }
}