using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Medicine medicine = medicineService.GetMedicineByName(MedicineName);
            if (medicineService.GetMedicineByName(MedicineName) != null)
            {
                return medicine.MedicineSpecificationID;
            }
            else
            {
                return "";
            }
        }
    }
}
