using WebApplication;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace WebApplicationTests
{
    public class SurveyAndStatisticsSeviceTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;
        public SurveyAndStatisticsSeviceTests(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
        }
        public static IEnumerable<object[]> Survey_Text =>
            new List<object[]>
            {
                        new object[] {"1,Klara Dicic,1,2,3,4,5,5,4,1,2,5,1,4,2,3,5,2,1,4,5,2,2,5,4,2020-12-12 00:00:00", HttpStatusCode.OK},
                        new object[] {null, HttpStatusCode.BadRequest}
            };

        [Theory]
        [MemberData(nameof(Survey_Text))]
        public async void Add_survey(string Survey_Text,
                    HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync("#/survey/add/" + Survey_Text);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}
