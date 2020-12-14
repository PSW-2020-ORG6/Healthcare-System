using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class ProcedureTypeDTO
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public ProcedureTypeDTO() { }
        public ProcedureTypeDTO(ProcedureType procedureType)
        {
            Name = procedureType.Name;
        }
    }
}
