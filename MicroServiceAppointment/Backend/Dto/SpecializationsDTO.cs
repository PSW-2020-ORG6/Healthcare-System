using MicroServiceAccount.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class SpecializationsDTO
    {
        public string Name { get; set; }

        public List<SpecializationsDTO> ConvertListToSpecializationDTO(List<Specialization> specializations)
        {
            List<SpecializationsDTO> specializationsDTO = new List<SpecializationsDTO>();
            foreach (Specialization specialization in specializations)
                if (!SpecializationExist(specialization.Name, specializationsDTO))
                    specializationsDTO.Add(new SpecializationsDTO { Name = specialization.Name });
            return specializationsDTO;
        }
        private bool SpecializationExist(string name, List<SpecializationsDTO> specializationsDTO)
        {
            foreach (SpecializationsDTO specializationDTO in specializationsDTO)
                if (specializationDTO.Name.Equals(name))
                    return true;
            return false;
        }
    }
}
