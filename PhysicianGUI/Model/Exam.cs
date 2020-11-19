using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class Exam
    {
        private String _patient;
        private int _age;
        private String _time;
        private String _room;
        private String _type;
        private bool _urgency;
        private bool _examFinished;

        public string Patient { get => _patient; set => _patient = value; }
        public int Age { get => _age; set => _age = value; }
        public string Time { get => _time; set => _time = value; }
        public string Room { get => _room; set => _room = value; }
        public string Type { get => _type; set => _type = value; }
        public bool Urgency { get => _urgency; set => _urgency = value; }
        public bool ExamFinished { get => _examFinished; set => _examFinished = value; }
    }
}
