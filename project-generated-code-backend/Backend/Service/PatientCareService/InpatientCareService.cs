// File:    InpatientCareService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class InpatientCareService

using Backend.Dto;
using Backend.Repository;
using Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;
using HealthClinic.Backend.Model.Hospital;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using System;
using System.Collections.Generic;

namespace Backend.Service.PatientCareService
{
    public class InpatientCareService
    {
        private Physician _loggedPhysician;
        private IInpatientCareRepository inpatientCareRepository;
        private IBedReservationRepository bedReservationRepository;
        private IRoomRepository roomRepository;

        public InpatientCareService(Physician loggedPhysician)
        {
            this._loggedPhysician = loggedPhysician;
            this.inpatientCareRepository = new InpatientCareFileSystem();
            this.bedReservationRepository = new BedReservationFileSystem();
            this.roomRepository = new RoomFileSystem();
        }

        public List<Room> GetAvailableRooms()
        {
            RoomAvailabilityService roomAvailabilityService = new RoomAvailabilityService();
            List<Room> rooms = new List<Room>();
            foreach (Room room in GetAllRooms())
            {
                if (roomAvailabilityService.IsRoomAvailableForInpatientCare(room))
                {
                    rooms.Add(room);
                }
            }

            Console.WriteLine("GET AVAILABLE ROOMS");
            foreach (Room r in rooms)
            {
                Console.WriteLine(r);
            }

            return rooms;
        }

        public List<Bed> GetAvailableBeds(Room room)
        {
            RoomAvailabilityService roomAvailabilityService = new RoomAvailabilityService();
            return roomAvailabilityService.GetAvailableBeds(room);
        }

        public void StartInpatientCare(BedReservationDTO bedReservationDTO)
        {
            bedReservationRepository.Save(new BedReservation(bedReservationDTO));
        }

        public void DischargeParient(Patient patient)
        {
            BedReservation activeBedReservation = bedReservationRepository.GetBedReservationByPatient(patient);
            bedReservationRepository.Delete(activeBedReservation.SerialNumber);
            DateTime dateOfAdmition = activeBedReservation.TimeInterval.Start;
            DateTime dateOfDischarge = DateTime.Now;
            InpatientCare inpatientCare = new InpatientCare(dateOfAdmition, dateOfDischarge, _loggedPhysician, patient);
            inpatientCareRepository.Save(inpatientCare);
        }

        public BedReservation GetActiveBedReservation(Patient patient)
        {
            return bedReservationRepository.GetBedReservationByPatient(patient);
        }

        public List<InpatientCare> GetAllInpatientCares(Patient patient)
        {
            return inpatientCareRepository.GetInpatientCaresForPatient(patient);
        }

        private List<Room> GetAllRooms()
        {
            return roomRepository.GetAll();
        }
    }
}