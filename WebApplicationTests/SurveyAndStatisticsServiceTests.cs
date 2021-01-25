using WebApplication;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;
using MicroServiceAppointment.Backend.Service;
using MicroServiceAppointment.Backend.Model.Survey;
using System;
using MicroServiceAppointment.Backend.Util;
using Moq;
using MicroServiceAppointment.Backend.Repository.Generic;

namespace WebApplicationTests
{
    public class SurveyAndStatisticsSeviceTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;

        private String doctorFalse = "Pera Peric";
        private String doctorTrue = "Gojko Simic";

        private List<Survey> getTestData()
        {
            List<Survey> retVal = new List<Survey>();

            Survey Survey1 = new Survey()
            {
                PatientId = "164423",
                DoctorName = "Gojko Simic",
                ReportDate = new DateTime(1975, 11, 11),
                Questions = new List<string>()
            };
            for (int i = 0; i < 23; i++)
            {
                Survey1.Questions.Add("5");
            }
            retVal.Add(Survey1);

            Survey Survey2 = new Survey()
            {
                PatientId = "12313",
                DoctorName = "Gojko Simic",
                ReportDate = new DateTime(1975, 11, 11),
                Questions = new List<string>()
            };
            for (int i = 0; i < 23; i++)
            {
                Survey2.Questions.Add("5");
            }
            retVal.Add(Survey2);

            Survey Survey3 = new Survey()
            {
                PatientId = "57745",
                DoctorName = "Gojko Simic",
                ReportDate = new DateTime(1975, 11, 11),
                Questions = new List<string>()
            };
            for (int i = 0; i < 23; i++)
            {
                Survey3.Questions.Add("3");
            }
            retVal.Add(Survey3);

            Survey Survey4 = new Survey()
            {
                PatientId = "123124",
                DoctorName = "Gojko Simic",
                ReportDate = new DateTime(1975, 11, 11),
                Questions = new List<string>()
            };
            for (int i = 0; i < 23; i++)
            {
                Survey4.Questions.Add("3");
            }
            retVal.Add(Survey4);

            return retVal;
        }

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

        [Fact]
        public void Statistics_each_question_correct()
        {
            var surveyRepository = new Mock<ISurveyRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();

            surveyRepository.Setup(m => m.GetAll()).Returns(getTestData());

            SurveyService service = new SurveyService(surveyRepository.Object,
                appointmentRepository.Object);

            List<StatisticAuxilaryClass> returnValue = service.GetStatisticsEachQuestion();

            bool assert = true;

            foreach (StatisticAuxilaryClass value in returnValue)
            {
                if (value.AverageRating != 4)
                {
                    assert = false;
                    break;
                }
            }

            Assert.True(assert);
        }


        [Fact]
        public void Statistics_each_question_topic_correct()
        {
            var surveyRepository = new Mock<ISurveyRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();

            surveyRepository.Setup(m => m.GetAll()).Returns(getTestData());

            SurveyService service = new SurveyService(surveyRepository.Object,
                appointmentRepository.Object);

            List<StatisticAuxilaryClass> returnValue = service.GetStatisticsEachTopic();

            bool assert = true;

            foreach (StatisticAuxilaryClass value in returnValue)
            {
                if (value.AverageRating != 4)
                {
                    assert = false;
                    break;
                }
            }

            Assert.True(assert);
        }

        [Fact]
        public void Statistics_doctor_doesnt_exist()
        {
            var surveyRepository = new Mock<ISurveyRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();

            surveyRepository.Setup(m => m.GetByDoctorName(doctorFalse)).Returns(new List<Survey>());

            SurveyService service = new SurveyService(surveyRepository.Object,
                appointmentRepository.Object);

            List<StatisticAuxilaryClass> returnValue = service.GetStatisticsForDoctor(doctorFalse);

            bool assert = true;
            foreach (StatisticAuxilaryClass value in returnValue)
            {
                if (!double.IsNaN(value.AverageRating))
                {
                    assert = false;
                }
            }


            Assert.True(assert);
        }

        [Fact]
        public void Statistics_doctor_exists()
        {
            var surveyRepository = new Mock<ISurveyRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();

            surveyRepository.Setup(m => m.GetByDoctorName(doctorTrue)).Returns(getTestData);

            SurveyService service = new SurveyService(surveyRepository.Object,
                appointmentRepository.Object);

            List<StatisticAuxilaryClass> returnValue = service.GetStatisticsForDoctor(doctorTrue);

            bool assert = true;
            foreach (StatisticAuxilaryClass value in returnValue)
            {
                if (value.AverageRating != 4)
                {
                    assert = false;
                }
            }


            Assert.True(assert);
        }

    }
}
