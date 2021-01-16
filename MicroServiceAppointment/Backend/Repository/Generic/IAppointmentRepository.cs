// File:    AppointmentRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface AppointmentRepository

using MicroServiceAccount.Backend.Model;
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IAppointmentRepository : IGenericMsAppointmentRepository<Appointment>
    {
        List<Appointment> GetAppointmentsByDate(DateTime date);

        List<Appointment> GetAppointmentsByPatient(Patient patient);

        List<Appointment> GetAppointmentsByPhysician(Physician physician);

        List<Appointment> GetAppointmentsByRoom(Room room);
        List<Appointment> GetByRoomSerialNumber(string roomSerialNumber);
        List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber);
        List<Appointment> GetByPatientSerialNumber(string patientSerialNumber);
        List<Appointment> GetByPatientId(string patientId);
        List<Appointment> GetByPatientIdActive(string patientId);
        List<Appointment> GetByPatientIdCanceled(string patientId);
        List<DateTime> GetByPatientIdCanceledDates(string patientId);
        List<Appointment> GetByPatientIdWithoutSurvey(string patientId);
        List<Appointment> GetByPatientIdWithSurvey(string patientId);
        List<Appointment> IsSurveyDoneByPatientIdAppointmentDatePhysicianNameAppointments(string patientId, string appointmentDate, string id);
        void Update(Appointment appointment);
        List<Appointment> GetDoneSurveyByPatentId(string patientId);
        List<Appointment> GetAllAppointmentsByPatientIdDateAndDoctor(string patientId, DateTime date, string doctorName);
    }
}