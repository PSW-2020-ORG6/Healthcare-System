using Model.Accounts;
using System;

namespace Backend.Dto
{
    public class SuggestedAppointmentDTO
    {
        private DateTime dateStart;
        private DateTime dateEnd;
        private Physician _physician;
        private Patient patient;
        private bool prior;

        public Physician Physician { get => _physician; set => _physician = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public DateTime DateStart { get => dateStart; set => dateStart = value; }
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }
        public bool Prior { get => prior; set => prior = value; }
    }
}
