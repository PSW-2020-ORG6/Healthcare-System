using HealthClinicBackend.Backend.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class SpecializationDTO
    {
        public string Name { get; set; }

        public List<SpecializationDTO> ConvertListToSpecializationDTO(List<Specialization> specializations)
        {
            List<SpecializationDTO> specializationsDTO = new List<SpecializationDTO>();
            foreach (Specialization specialization in specializations)
                if (!SpecializationExist(specialization.Name, specializationsDTO))
                    specializationsDTO.Add(new SpecializationDTO { Name = specialization.Name });
            return specializationsDTO;
        }
        private bool SpecializationExist(string name, List<SpecializationDTO> specializationsDTO)
        {
            foreach (SpecializationDTO specializationDTO in specializationsDTO)
                if (specializationDTO.Name.Equals(name))
                    return true;
            return false;
        }
    }
}
