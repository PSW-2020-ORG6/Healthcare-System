using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class MedicineDosage
    {
        private String _medicine;
        private double _ammount;
        private string _note;

        public String Medicine { get => _medicine; set => _medicine = value; }
        public double Ammount { get => _ammount; set => _ammount = value; }
        public string Note { get => _note; set => _note = value; }
    }
}
