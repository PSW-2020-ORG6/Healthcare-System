using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    class Patient
    {
        private string _name;
        private DateTime _dateOfBirth;
        private string _jmbg;
        private DateTime _lastAppointment;
        private DateTime _nextAppointment;

        public string Name { get => _name; set => _name = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string Jmbg { get => _jmbg; set => _jmbg = value; }
        public DateTime LastAppointment { get => _lastAppointment; set => _lastAppointment = value; }
        public DateTime NextAppointment { get => _nextAppointment; set => _nextAppointment = value; }
    }
}
