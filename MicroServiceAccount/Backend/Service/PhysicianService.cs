using MicroServiceAccount.Backend.Dto;
using MicroServiceAccount.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAccount.Backend.Service
{
    public class PhysicianService
    {
        private ISpecializationRepository _specializationRepository;
        private IPhysicianRepository _physicianRepository;

        private PhysicianDTO physitianDTO = new PhysicianDTO();
        private SpecializationDTO specializationDTO = new SpecializationDTO();
        public PhysicianService(ISpecializationRepository specializationRepository, IPhysicianRepository physicianRepository)
        {
            _specializationRepository = specializationRepository;
            _physicianRepository = physicianRepository;
        }

        /// <summary>
        ///calls method for get all physicians in physician table
        ///</summary>
        ///<returns>
        ///list of physicians
        ///</returns>
        public List<PhysicianDTO> GetAllPhysician()
        {
            return physitianDTO.ConvertListToPhysicianDTO(_physicianRepository.GetAll());
        }

        /// <summary>
        ///Get patient from physicians table by ID
        ///</summary>
        ///<returns>
        ///single instance of Physician object
        ///</returns
        public PhysicianDTO GetPhysicianById(string physicianId)
        {
            return new PhysicianDTO(_physicianRepository.GetById(physicianId));
        }

        /// <summary>
        ///calls method for get all specialization in specialization table
        ///</summary>
        ///<returns>
        ///list of specialization
        ///</returns>
        public List<SpecializationDTO> GetAllSpecialization()
        {
            return specializationDTO.ConvertListToSpecializationDTO(_specializationRepository.GetAll());
        }
    }
}
