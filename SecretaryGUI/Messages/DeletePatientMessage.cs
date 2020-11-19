using Model.Accounts;
using System;

namespace HCI_SIMS_PROJEKAT.Messages
{
    public class DeletePatientMessage
    {
        private Patient _patient;
        public Patient patient { get { return _patient; } internal set { _patient = value; Console.WriteLine("U PORUCI SAM"); } }
    }
}