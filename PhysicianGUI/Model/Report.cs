using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class Report
    {
        private string _procedureType;
        private DateTime _date;
        private string _physitian;
        private List<DocumentPreview> documents;

        public string ProcedureType { get => _procedureType; set => _procedureType = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string Physitian { get => _physitian; set => _physitian = value; }
        public List<DocumentPreview> Documents { get => documents; set => documents = value; }
    }
}
