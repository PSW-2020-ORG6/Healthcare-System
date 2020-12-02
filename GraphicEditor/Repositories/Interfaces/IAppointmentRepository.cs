using Model.Schedule;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentBySerialNumber(string serialNumber);
        List<Appointment> GetAppointmentByRoomSerialNumber(string roomSerialNumber);
        List<Appointment> GetAppointmentByPhysitianSerialNumber(string physitianSerialNumber);
        List<Appointment> GetAppointmentByPatientSerialNumber(string patientSerialNumber);
    }
}
