using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class PhysicianDTO
    {
        private string fullName;
        private string id;
        private List<SpecializationDTO> specializations;

        public PhysicianDTO()
        {
        }

        public PhysicianDTO(Physician physician)
        {
            SpecializationDTO specializationDTO = new SpecializationDTO();
            Id = physician.Id;
            FullName = physician.FullName;
            Specializations = specializationDTO.ConvertListToSpecializationDTO(physician.Specialization);
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<SpecializationDTO> Specializations
        {
            get { return specializations; }
            set { specializations = value; }
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
