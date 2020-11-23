using health_clinic_class_diagram.Backend.Model.Survey;
using Moq;
using System;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddNewSurveyTest()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var result = true;
            Survey surveyTest = new Survey
            ("001", "Bozo Bozic", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3");
            stubRepository.Setup(m => m.AddNewSurvey(surveyTest)).Returns(result);
            SurveyService service = new SurveyService(stubRepository.Object);
            bool result1 = service.AddNewSurvey(surveyTest);
            Assert.True(result1);
        }
    }
}
