using MicroServiceAccount.Backend.Dto;
using MicroServiceSearch.Backend.Dto;
using MicroServiceSearch.Backend.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceSearch.Backend.Util
{
    public class HttpRequest
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<PatientDto> GetPatientByIdAsync(string patientId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getPatientById/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PatientDto>(await response.Content.ReadAsStringAsync());
        }
        public static async Task<PhysicianDTO> GetPhysiciantByIdAsync(string physicianId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/physicianMicroservice/getPhysicianById/" + physicianId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PhysicianDTO>(await response.Content.ReadAsStringAsync());
        }
        public static async Task<ProcedureTypeDTO> GetProcedureTypeByIdAsync(string procedureTypeId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/getProcedureTypeById/" + procedureTypeId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<ProcedureTypeDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
