using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Report.Models
{
    public class Interval
    {
        private string start;

        public string Start
        {
            get { return start; }
            private set { start = value; }
        }
        private string end;
        public string End
        {
            get { return end; }
            private set { end = value; }
        }

        [JsonConstructor]
        public Interval(String start, String end)
        {
            this.start = start;
            this.end = end;
        }

        public Interval() { }
    }
}
