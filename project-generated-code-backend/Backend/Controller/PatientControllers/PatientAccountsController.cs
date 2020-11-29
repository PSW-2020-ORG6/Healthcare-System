using health_clinic_class_diagram.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Controller.PatientControllers
{
    class PatientAccountsController
    {
        public PatientAccountsService patientAccountsService;

        public PatientAccountsController()
        {
            this.patientAccountsService = new PatientAccountsService();
        }

        public List<Patient> getPatientsByRoom(Room room)
        {
            return patientAccountsService.getPatientsByRoom(room);
        }
    }
}
