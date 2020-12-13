using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{

    public class Api
    { 
        [Key]
        public string Key { get; set; }
        public string PharmacyName { get; set; }
        public string Url { get; set; }

        public Boolean Subscribed { get; set; }

        public Api() {}

        public Api(string Key, string PharmacyName, string Url)
        {
            this.Key = Key;
            this.PharmacyName = PharmacyName;
            this.Url = Url;
        }
    }
}
