using MicroServiceSearch;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace WebApplicationTests
{
    public class ReportAndPrescriptionTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;
        public ReportAndPrescriptionTest(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
        }
        public static IEnumerable<object[]> ReportAndPrescription =>
            new List<object[]>
            {
                        new object[] {"2020-12-06", "1", "1", HttpStatusCode.OK},
                        new object[] {null, null, null, HttpStatusCode.BadRequest}
            };

        [Theory]
        [MemberData(nameof(ReportAndPrescription))]
        public async void Get_report_and_prescritpion(string date, string patientId, string physicianId,
                    HttpStatusCode exceptedStatusCode)
        {
            //HttpClient client = webFactory.CreateClient();
            //HttpResponseMessage responseMessage =
            //    await client.GetAsync("http://localhost:49900/search/getReportByAppointment/" + date + "/" 
            //                          + patientId + "/" + physicianId);

            //responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}
