using health_clinic_class_diagram.Backend.Model.Survey;
using Moq;
using System;
using System.Collections.Generic;
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

        [Fact]
        public void calculation_of_statistics()
        {
            
            List<double> testResult = new List<double>();
            for (int i=0; i < 6 ; i++) {
                testResult.Add(2);
            }


            Survey surveyTest1 = new Survey
            ("001", "Bozo Bozic", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3");
            Survey surveyTest2 = new Survey
            ("001", "Bozo Bozic", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1");

            List<Survey> testInput = new List<Survey>();
            testInput.Add(surveyTest1);
            testInput.Add(surveyTest2);

            var stubRepository = new Mock<ISurveyRepository>();
            var result = testResult;




            stubRepository.Setup(m => m.calculateStatistics(testInput)).Returns(result);
            SurveyService service = new SurveyService(stubRepository.Object);
            List<double> result1 = service.calculateStatistics(testInput);

            bool finalResult = false;

            for (int i = 0; i < 6;  i++) {
                if (result1[i] != testResult[i])
                {
                    finalResult = false;
                    break;
                }
                else {
                    finalResult = true;
                }
            
            } 

            Assert.True(finalResult);
          
        }
    }
}
