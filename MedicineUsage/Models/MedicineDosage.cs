using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineUsage.Models
{
    
    public class MedicineDosage
    {
        [Key]
        private int id;
        private string medicineName;
        private int amount;

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string MedicineName
        {
            get { return medicineName; }
            private set { medicineName = value; }
        }

        public int Amount
        {
            get { return amount; }
            private set { amount = value; }
        }

        public MedicineDosage(int id, string MedicineName, int Amount)
        {
            this.Id = id;
            this.MedicineName = MedicineName;
            this.Amount = Amount;
        }
    }

}
