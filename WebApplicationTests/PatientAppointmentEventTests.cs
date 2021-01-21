using MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WebApplication;
using Xunit;

namespace PatientAppointmentEventTests
{
    public class PatientAppointmentEventTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;
        public PatientAppointmentEventTests(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
        }

        public static IEnumerable<object[]> Event =>
            new List<object[]>
            {
                new object[] { new PatientAppointmentEvent
            {
                TransitionsFromFourToThreeStep = 0,
                TransitionsFromThreeToTwoStep = 2,
                TransitionsFromTwoToOneStep = 1,
                IsAppointmentScheduled = true,
                SchedulingDuration = "12:00"
            }, HttpStatusCode.OK},
                new object[] {null, HttpStatusCode.BadRequest}
            };

        [Theory]
        [MemberData(nameof(Event))]
        public async void Add_event(PatientAppointmentEvent @event, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/event/addEvent/" +  @event);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}