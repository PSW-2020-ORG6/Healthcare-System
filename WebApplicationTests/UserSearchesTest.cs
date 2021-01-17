using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WebApplication;
using Xunit;

namespace UserSearchTest
{
    public class UserSearchTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;

        public UserSearchTests(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
        }

        public static IEnumerable<object[]> Search =>
            new List<object[]>
            {
                new object[] {" a,All", "2020-12-25", "2020-12-25", HttpStatusCode.OK},
                new object[] {null, null, null, HttpStatusCode.BadRequest}
            };

        [Theory]
        [MemberData(nameof(Search))]
        public async void Get_prescriptions_search(string search, string dateTo, string dateFrom,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/search/prescriptionsSearch/" + search + "/" + dateTo + "/" + dateFrom);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(Search))]
        public async void Get_reports_search(string search, string dateTo, string dateFrom,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/search/reportsSearch/" + search + "/" + dateTo + "/" + dateFrom);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}