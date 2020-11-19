using Backend.Controller.PhysitianControllers;
using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.FrontendAdapters
{
    class PatientAdapter
    {
        private Patient patient;
        private Appointment previousAppointment;
        private Appointment nextAppointment;

        public PatientAdapter(Patient patient, Appointment previousAppointment, Appointment nextAppointment)
        {
            this.patient = patient;
            this.previousAppointment = previousAppointment;
            this.nextAppointment = nextAppointment;
        }

        public String FullName
        {
            get
            {
                return Patient.Name + " " + Patient.Surname;
            }
        }

        public String Id
        {
            get
            {
                return Patient.Id;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return Patient.DateOfBirth;
            }
        }

        public String NextAppointment
        {
            get
            {
                if(nextAppointment == null)
                {
                    return "";
                }

                return nextAppointment.ProcedureType.Name + " " + nextAppointment.TimeInterval.Start.ToString("dd.MM.yyy.");
            }
        }

        public String PreviousAppointment
        {
            get
            {
                if (previousAppointment == null)
                {
                    return "";
                }
                return previousAppointment.ProcedureType.Name + " " + previousAppointment.TimeInterval.Start.ToString("dd.MM.yyy.");
            }
        }

        public Patient Patient { get => patient; }

        public override bool Equals(object obj)
        {
            PatientAdapter other = obj as PatientAdapter;

            if(other == null)
            {
                return false;
            }

            return this.Patient.Equals(other.Patient);
        }
    }
}
