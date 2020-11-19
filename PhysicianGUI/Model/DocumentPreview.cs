using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class DocumentPreview
    {
        private String type;
        private String details;

        public string Type { get => type; set => type = value; }
        public string Details { get => details; set => details = value; }
    }
}
