using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.SchedulingService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class AppointmentController
    {
        public AppointmentService appointmentService;

        public AppointmentController()
        {
            appointmentService = new AppointmentService();
        }

        public Appointment GetById(string id)
        {
            return appointmentService.GetById(id);
        }

        public List<Appointment> GetAll()
        {
            return appointmentService.GetAll();
        }

        public void EditAppointment(Appointment appointment)
        {
            appointmentService.EditAppointment(appointment);
        }

        public void NewAppointment(AppointmentDto appointmentDto)
        {
            appointmentService.NewAppointment(appointmentDto);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointmentService.DeleteAppointment(appointment);
        }
    }
}