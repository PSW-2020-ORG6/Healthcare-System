using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class Advertisement
    {
        List<ActionAndBenefitMessage> actionAndBenefitMessages = new List<ActionAndBenefitMessage>();

        [Fact]
        public void Advertisements()
        {
            var stubRepository = new Mock<IActionsAndBenefitsRepository>();
            actionAndBenefitMessages.Add(new ActionAndBenefitMessage { DateFrom = new DateTime(2020, 12, 5), DateTo = new DateTime(2021, 12, 5), Text = "Health", PharmacyName="Health" });
            stubRepository.Setup(m => m.GetAllPublishedActionsAndBenefitsMessages()).Returns(actionAndBenefitMessages);
            PatientService service = new PatientService(stubRepository.Object);

            List<ActionAndBenefitMessage> list = service.GetAdvertisements();

            Assert.NotNull(list);
        }

        [Fact]
        public void No_advertisements()
        {
            var stubRepository = new Mock<IActionsAndBenefitsRepository>();
            actionAndBenefitMessages.Add(new ActionAndBenefitMessage { DateFrom = new DateTime(2020, 12, 5), DateTo = new DateTime(2020, 12, 9), Text = "Health", PharmacyName = "Health" });
            stubRepository.Setup(m => m.GetAllPublishedActionsAndBenefitsMessages()).Returns(actionAndBenefitMessages);
            PatientService service = new PatientService(stubRepository.Object);

            List<ActionAndBenefitMessage> list = service.GetAdvertisements();

            Assert.Empty(list);
        }
    }
}
