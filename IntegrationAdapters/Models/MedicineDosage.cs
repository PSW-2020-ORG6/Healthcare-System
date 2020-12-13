using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    
    public class MedicineDosage
    {
        [Key]
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public int Amount { get; set; }

        public MedicineDosage(int id, string MedicineName, int Amount)
        {
            this.Id = id;
            this.MedicineName = MedicineName;
            this.Amount = Amount;
        }
    }
}
