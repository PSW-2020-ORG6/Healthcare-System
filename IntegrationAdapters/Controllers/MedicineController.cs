using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;

namespace IntegrationAdapters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicineController
    {
        private readonly MedicineService medicineService;

        public MedicineController()
        {
            this.medicineService = new MedicineService();
        }
        [HttpGet("getMedicineSpecification/{MedicineName}")]
        public String GetMedicineSpeification(String MedicineName)
        {
            MedicinePharmacy medicinePharmacy = medicineService.GetMedicineByName(MedicineName);
            if (medicineService.GetMedicineByName(MedicineName) != null)
            {
                return medicinePharmacy.MedicineSpecificationID;
            }
            else
            {
                return "";
            }
        }
    }
}
