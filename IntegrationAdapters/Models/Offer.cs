using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class Offer
    {
        [Key]
        public string CompanyEmail { get; set; }
        public string CompanyName { get; set; }
        public int UnitPrice { get; set; }
        public string TenderName { get; set; }

        public Offer() { }
        public Offer(string companyName,string companyEmail, int unitPrice, string tenderName)
        {
            this.CompanyName = companyName;
            this.CompanyEmail = companyEmail;
            this.UnitPrice = unitPrice;
            this.TenderName = tenderName;
        }
    }
}
