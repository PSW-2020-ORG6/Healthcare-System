using MicroServiceAppointment.Backend.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Util
{
    public class HttpRequest
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<PatientsDTO> GetPatientByIdAsync(string patientId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getPatientById/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PatientsDTO>(await response.Content.ReadAsStringAsync());
        }
        public static async Task<PhysiciansDTO> GetPhysiciantByIdAsync(string physicianId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/physicianMicroservice/getPhysicianById/" + physicianId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PhysiciansDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
