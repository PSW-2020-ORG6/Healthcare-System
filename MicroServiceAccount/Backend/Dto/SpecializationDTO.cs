using MicroServiceAccount.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAccount.Backend.Dto
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
