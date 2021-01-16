using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication;
using Xunit;
using MicroServiceAppointment.Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService;

namespace WebApplicationTests
{
    public class CreateAppointmentTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;

        public CreateAppointmentTests(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
        }

        public static IEnumerable<object[]> AppointmentDate =>
            new List<object[]>
            {
                new object[] {"60001", "surgeon", "2020-12-25", HttpStatusCode.OK},
                new object[] {null, null, null, HttpStatusCode.BadRequest}
            };

        public static IEnumerable<object[]> Specialization =>
            new List<object[]>
            {
                new object[] {"60001", HttpStatusCode.OK},
                new object[] {null, HttpStatusCode.BadRequest}
            };


        [Theory]
        [MemberData(nameof(Specialization))]
        public async void Get_specializtions(string specialization, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/specializations/" + specialization);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment(string id, string spec, string date,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/GetAllAvailableAppointments/" + id + "/" + spec + "/" + date);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment_with_recommandation_physician(string id, string spec, string date,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync(
                    "/#/appointment/appointmentsWithPhysicianPriority/" + id + "/" + spec + "/" + date);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment_with_recommandation_date(string id, string spec, string date,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/appointmentsWithReccomendation/" + id + "/" + spec + "/" + date);
            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}