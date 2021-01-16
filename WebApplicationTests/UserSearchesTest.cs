using MicroServiceSearch;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace WebApplicationTests
{
    public class UserSearchesTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;
        public UserSearchesTest(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
        }
        public static IEnumerable<object[]> UserSearches =>
            new List<object[]>
            {
                        new object[] {" ,a,All", "2020-12-06", "2020-12-16", HttpStatusCode.OK},
                        new object[] {null, null, null, HttpStatusCode.BadRequest}
            };

        [Theory]
        [MemberData(nameof(UserSearches))]
        public async void Get_prescription_search(string date, string patientId, string physicianId,
                    HttpStatusCode exceptedStatusCode)
        {
            //HttpClient client = webFactory.CreateClient();
            //HttpResponseMessage responseMessage =
            //    await client.GetAsync("http://localhost:49900/search/prescriptionSearch/" + date + "/"
            //                          + patientId + "/" + physicianId);

            //responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(UserSearches))]
        public async void Get_report_search(string date, string patientId, string physicianId,
            HttpStatusCode exceptedStatusCode)
        {
            //HttpClient client = webFactory.CreateClient();
            //HttpResponseMessage responseMessage =
            //    await client.GetAsync("http://localhost:49900/search/reportSearch/" + date + "/"
            //                          + patientId + "/" + physicianId);

            //responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}
