using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.Accounts;

namespace WebApplication.Backend.DTO
{
    public class PhysicianDTO
    {
        public string FullName { get; set; }
        public string Id { get; set; }
        public List<SpecializationDTO> Specializations { get; set; }

        public PhysicianDTO()
        {
        }

        public PhysicianDTO(Physician physician)
        {
            SpecializationDTO specializationDTO = new SpecializationDTO();
            Id = physician.Id;
            FullName = physician.Name + " " + physician.Surname;
            Specializations = specializationDTO.ConvertListToSpecializationDTO(physician.Specialization);
        }

        public List<PhysicianDTO> ConvertListToPhysicianDTO(List<Physician> physicians)
        {
            List<PhysicianDTO> physiciansDTO = new List<PhysicianDTO>();
            foreach (Physician physician in physicians)
                physiciansDTO.Add(new PhysicianDTO(physician));
            return physiciansDTO;
        }
    }
}
