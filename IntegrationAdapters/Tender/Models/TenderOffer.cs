using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class TenderOffer
    {
        [Key]
        public string Id { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyName { get; set; }
        public string TenderName { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public TenderOffer(){ }

        public TenderOffer(string id,string companyEmail, string companyName, string tenderName, string medicineName, int quantity, int price)
        {
            Id = id;
            CompanyEmail = companyEmail;
            CompanyName = companyName;
            TenderName = tenderName;
            MedicineName = medicineName;
            Quantity = quantity;
            Price = price;
        }
    }
}
