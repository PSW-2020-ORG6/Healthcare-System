using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.FrontendAdapters
{
    class MedicineAdapter
    {
        private Medicine medicine;
        private bool isApproved;

        public MedicineAdapter(Medicine medicine, bool isApproved)
        {
            this.Medicine = medicine;
            this.IsApproved = isApproved;
        }

        public Medicine Medicine { get => medicine; set => medicine = value; }
        public bool IsApproved { get => isApproved; set => isApproved = value; }

        public override bool Equals(object obj)
        {
            MedicineAdapter other = obj as MedicineAdapter;
            if(other == null)
            {
                return false;
            }
            return this.Medicine.CopyrightName.Equals(other.Medicine.CopyrightName);
        }
    }
}
