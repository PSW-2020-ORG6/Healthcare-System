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

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class InpatientCareController
    {
        private Physician _loggedPhysician;
        private InpatientCareService inpatientCareService;

        public InpatientCareController(Physician loggedPhysician, InpatientCareService inpatientCareService)
        {
            this._loggedPhysician = loggedPhysician;
            this.inpatientCareService = inpatientCareService;
        }

        public void StartInpatientCare(BedReservationDto bedReservationDTO)
        {
            inpatientCareService.StartInpatientCare(bedReservationDTO);
        }

        public void DischargeParient(Patient patient)
        {
            inpatientCareService.DischargePatient(patient);
        }

        public BedReservation getActiveInpatientCare(Patient patient)
        {
            return inpatientCareService.GetActiveBedReservation(patient);
        }

        public List<InpatientCare> getPreviousInpatientCares(Patient patient)
        {
            return inpatientCareService.GetAllInpatientCares(patient);
        }

        public List<Room> GetAvailableRooms()
        {
            return inpatientCareService.GetAvailableRooms();
        }

        public List<Bed> GetAvailableBeds(Room room)
        {
            return inpatientCareService.GetAvailableBeds(room);
        }
    }
}