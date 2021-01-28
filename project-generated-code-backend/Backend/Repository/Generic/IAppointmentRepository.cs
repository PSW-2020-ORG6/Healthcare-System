// File:    AppointmentRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface AppointmentRepository

using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        List<Appointment> GetAppointmentsByDate(DateTime date);
        List<Appointment> GetByRoomSerialNumber(string roomSerialNumber);
        List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber);
        List<Appointment> GetByPatientSerialNumber(string patientSerialNumber);
        Appointment GetBySerialNumber(string serialNumber);
        List<Appointment> GetAppointmentsByPatient(Patient patient);
        List<Appointment> GetAppointmentsByPhysician(Physician physician);
        List<Appointment> GetAppointmentsByRoom(Room room);
        List<Appointment> GetByPatientId(string patientId);
        List<Appointment> GetByPatientIdActive(string patientId);
        List<Appointment> GetByPatientIdCanceled(string patientId);
        List<string> GetByPatientIdCanceledDates(string patientId);
        List<Appointment> GetByPatientIdWithoutSurvey(string patientId);
        List<Appointment> GetByPatientIdWithSurvey(string patientId);
        List<Appointment> IsSurveyDoneByPatientIdAppointmentDatePhysicianNameAppointments(string patientId, string appointmentDate, string id);
        void Update(Appointment appointment);
    }
}