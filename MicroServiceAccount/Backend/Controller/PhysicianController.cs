using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using MicroServiceAccount.Backend.Dto;
using MicroServiceAccount.Backend.Service;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("physicianMicroservice")]
    [ApiController]
    public class PhysicianController : ControllerBase
    {
        private readonly PhysicianService _physicianService;

        public PhysicianController(PhysicianService physicianService)
        {
           _physicianService = physicianService;
        }

        [Authorize]
        [HttpGet("allPhysicians")]
        public List<PhysicianDTO> GetAllPhysicians()
        {
            return _physicianService.GetAllPhysician();
        }

        [Authorize]
        [HttpGet("getPhysicianById/{physicianId}")]
        public PhysicianDTO GetPatientById(string physicianId)
        {
            return _physicianService.GetPhysicianById(physicianId);
        }

        [Authorize]
        [HttpGet("allSpecializations")]
        public List<SpecializationDTO> GetAllSpecializations()
        {
            return _physicianService.GetAllSpecialization();
        }
    }
}
