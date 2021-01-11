using MicroServiceAccount.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class PhysiciansDTO
    {
        public string FullName { get; set; }
        public string Id { get; set; }
        public List<SpecializationsDTO> Specializations { get; set; }

        public PhysiciansDTO()
        {
        }

        public PhysiciansDTO(Physician physician)
        {
            SpecializationsDTO specializationDTO = new SpecializationsDTO();
            Id = physician.Id;
            FullName = physician.Name + " " + physician.Surname;
            Specializations = specializationDTO.ConvertListToSpecializationDTO(physician.Specialization);
        }

        public List<PhysiciansDTO> ConvertListToPhysicianDTO(List<Physician> physicians)
        {
            List<PhysiciansDTO> physiciansDTO = new List<PhysiciansDTO>();
            foreach (Physician physician in physicians)
                physiciansDTO.Add(new PhysiciansDTO(physician));
            return physiciansDTO;
        }
    }
}
