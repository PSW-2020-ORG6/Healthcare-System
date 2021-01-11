using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class Interval
    { 
        public string start { get; set; }
        public string end { get; set; }

        public Interval() { }
    }
}
