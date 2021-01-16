using MicroServiceAccount.Backend.Model;
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

        internal static async Task<SpecializationsDTO> GetSpecializationByIdAsync(string specializationSerialNumber)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/physicianMicroservice/getSpecializationById/" + specializationSerialNumber);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<SpecializationsDTO>(await response.Content.ReadAsStringAsync());
        }
        public static async Task<List<PhysiciansDTO>> GetPhysycianByName(string physicianName)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/physicianMicroservice/getPhysicianByName/" + physicianName);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<PhysiciansDTO>>(await response.Content.ReadAsStringAsync());
        }
        public static async Task<AppointmentDto> GetAppointmentByPatientId(string patientId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsByPatientId/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<AppointmentDto>(await response.Content.ReadAsStringAsync());
        }

        public static async Task<AppointmentDto> UpdateAppointment(AppointmentDto appointmentDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(appointmentDTO, Formatting.Indented), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("http://localhost:57056/appointmentMicroservice/update/", content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<AppointmentDto>(await response.Content.ReadAsStringAsync());
        }
    
        public static async Task<List<AppointmentDto>> GetAllAppointmentsByPatientIdDateAndDoctor(string patientId, string reportDate, string physicianName)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/getAllAppointmentsByPatientIdDateAndDoctor/" + patientId + "/" + reportDate + "/" + physicianName);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

    }
}
