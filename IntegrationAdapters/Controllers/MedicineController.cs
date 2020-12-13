﻿using IntegrationAdapters.gRPCProtocol;
using IntegrationAdapters.Models;
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
        private readonly ClientScheduleService grpcService;
        private readonly NetGrpcServiceImpl grpcResponseService;

        public MedicineController()
        {
            this.medicineService = new MedicineService();
            this.grpcService = new ClientScheduleService();
            this.grpcResponseService = new NetGrpcServiceImpl();
        }
        [HttpGet("getMedicineSpecification/{medicineName}")]
        public IActionResult GetMedicineSpeification(string medicineName)
        {
            Medicine medicine = medicineService.DoesMedicineExist(medicineName);
            if (medicine != null)
            {
                 medicineService.GenerateSpecificationFromHospital(medicineName);
                
                return Ok();              
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("prescribeMedicine")]
        public IActionResult PrescribeMedicine(PrescriptionDTO prescription)
        {
            medicineService.GeneratePrescription(prescription);
            return Ok();
        }

        [HttpGet("getSpecification/{medicineName}")]
        public IActionResult GetSpecification(string medicineName)
        {
            var endPoint = "http://localhost:8082/myapp/medication/getSpecification/" + medicineName;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream receiveStream = webResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode);
            string text = readStream.ReadToEnd();
            if (IsResponseValid(text))
            {
                medicineService.GenerateSpecificationFromPharmacy(text, medicineName);
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }

        private bool IsResponseValid(string text)
        {
            return text.Length != 0;

        }

        [HttpPost("sendMessageGrpc")]
        public IActionResult SendMessageGrpc(MedicineMessage medicineMessage)
        {
            grpcService.SendMessageToPharmacy(medicineMessage);
            return Ok();
        }

        [HttpGet("getMessageGrpc")]
        public IActionResult GetActionsAndBenefits()
        {
            return Ok(Program.ResponseMessageGrpc);
        }
    }
}
