﻿using IntegrationAdapters.Models;
using IntegrationAdapters.Models.DTO;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace IntegrationAdapters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
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

        [HttpPost("prescribeMedicine")]
        public IActionResult PrescribeMedicine(PrescriptionDTO prescription)
        {
            medicineService.GeneratePrescription(prescription);
            return Ok();
        }

        [HttpGet("getSpecification/{MedicineName}")]
        public IActionResult GetSpecification(string MedicineName)
        {
            var endPoint = "http://localhost:8082/myapp/medication/getSpecification/" + MedicineName;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream receiveStream = webResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode);
            string text = readStream.ReadToEnd();
            if (IsResponseValid(text))
            {
                medicineService.GenerateSpecification(text, MedicineName);
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }

        private bool IsResponseValid(string text)
        {
            if (text.Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
