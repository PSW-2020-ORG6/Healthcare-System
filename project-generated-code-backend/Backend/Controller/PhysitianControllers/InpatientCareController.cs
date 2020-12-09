// File:    InpatientCareController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class InpatientCareController

using Backend.Dto;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.PatientCareService;

namespace Backend.Controller.PhysitianControllers
{
    public class InpatientCareController
    {
        private Physician _loggedPhysician;
        private InpatientCareService inpatientCareService;

        public InpatientCareController(Physician loggedPhysician)
        {
            this._loggedPhysician = loggedPhysician;
            this.inpatientCareService = new InpatientCareService(loggedPhysician);
        }

        public void StartInpatientCare(BedReservationDTO bedReservationDTO)
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