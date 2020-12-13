using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentBySerialNumber(string serialNumber);
        List<Appointment> GetAppointmentByRoomSerialNumber(string roomSerialNumber);
        List<Appointment> GetAppointmentByPhysitianSerialNumber(string physitianSerialNumber);
        List<Appointment> GetAppointmentByPatientSerialNumber(string patientSerialNumber);
        List<Appointment> GetAllAppointmentByPatientId(string patientId);
        List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId);
        List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId);
        List<Appointment> GetAppointmentsByDate(string date);
        bool AddAppointment(Appointment appointment);
    }
}
