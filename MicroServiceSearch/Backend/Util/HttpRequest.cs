using HealthClinicBackend.Backend.Dto;
using MicroServiceAccount.Backend.Dto;
using MicroServiceSearch.Backend.DTO;
//using HealthClinicBackend.Backend.Dto;
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

        public static async Task<HealthClinicBackend.Backend.Dto.PatientDto> GetPatientByIdAsync(string patientId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getPatientById/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<HealthClinicBackend.Backend.Dto.PatientDto>(await response.Content.ReadAsStringAsync());
        }
        public static async Task<HealthClinicBackend.Backend.Dto.PhysicianDTO> GetPhysiciantByIdAsync(string physicianId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getPhysicianById/" + physicianId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<HealthClinicBackend.Backend.Dto.PhysicianDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
