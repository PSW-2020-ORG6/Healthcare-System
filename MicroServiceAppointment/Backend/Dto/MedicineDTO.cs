using MicroServiceAppointment.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class MedicineDTO
    {
        public MedicineDTO()
        {

        }
        public MedicineDTO(Medicine medicine)
        {
            Id = medicine.SerialNumber;
            Name = medicine.GenericName;
            MedicineType = medicine.MedicineType.Type;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string MedicineType { get; set; }
    }
}
