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
        public string ApiKey { get; set; }
        public string PharmacyName { get; set; }
        public string Url { get; set; }

        public Api() {}

    }
}
