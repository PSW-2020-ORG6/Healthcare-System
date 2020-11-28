using Autofac.Extras.Moq;
using health_clinic_class_diagram.Backend.Model.Survey;
using Moq;
using System;
using System.Collections.Generic;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Services;
using WebApplication.Backend.Util;
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
        /*
            [Fact]
            public void getStatistiEachTopic()
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





                Assert.True(true);
          
            }
            */
            [Fact]
            public void getStatisticEachQuestion_correct()
            {
                using (var mock = AutoMock.GetLoose()) {
                    mock.Mock<ISurveyRepository>()
                        .Setup(x => x.getStatisticsEachQuestion())
                        .Returns(getSampleStatisticsEachQuestion());

                var cls = mock.Create<SurveyService>();
                List<StatisticAuxilaryClass> expected = getSampleStatisticsEachQuestion();

                List<StatisticAuxilaryClass> actual = cls.getStatisticsEachQuestion();



                bool flag = true;

                for (int i = 0; i < actual.Count; i++) {
                    flag = compareStatisticAuxilaryClass(actual[i], expected[i]);
                    if (flag == false)
                        break;
                }

                Assert.True(flag);
                }

            }

        private bool compareStatisticAuxilaryClass(StatisticAuxilaryClass p1 , StatisticAuxilaryClass p2) {
            
            if (p1.AverageRating != p2.AverageRating)
                return false;
            else if (p1.Ones != p2.Ones)
                return false;
            else if (p1.Twos != p2.Twos)
                return false;
            else if (p1.Threes != p2.Threes)
                return false;
            else if (p1.Fours != p2.Fours)
                return false;
            else if (p1.Fives != p2.Fives)
                return false;
   
            return true;
        }


            private List<StatisticAuxilaryClass> getSampleStatisticsEachQuestion() 
            {
                List<StatisticAuxilaryClass> output = new List<StatisticAuxilaryClass>
                {
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                      new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                        new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                      new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                        new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                       },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                      new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                        new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    },
                    new StatisticAuxilaryClass
                    {
                        AverageRating = 1,
                        Ones = 2,
                        Twos = 0,
                        Threes = 0,
                        Fours = 0,
                        Fives = 0,
                        OnesPercent = "100%",
                        TwosPercent = "0%",
                        ThreesPercent = "0%",
                        FoursPercent = "0%",
                        FivesPercent = "0"
                    }

                };

                return output;
            }

        }
}
