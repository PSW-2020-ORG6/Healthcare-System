using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using IntegrationAdapters;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using Xunit;
using IntegrationAdapters.Services;

namespace IntegrationAdaptersTests
{
    public class ActionsAndBenefitsTests
    {
        public Mock<IActionsAndBenefitsRepository> mock;
        public static Guid guid = new Guid("0e89a9a7-2722-45bb-a3de-7832131dcfe3");
        public static Guid guid2 = new Guid("a69b4d8e-55ce-4cdf-bfa6-7462e085a909");
        public ActionAndBenefitMessage actionAndBenefitMessage1 = new ActionAndBenefitMessage(guid, "Jankovic", "50% off brufen", new DateTime(2020, 5, 21), new DateTime(2020, 6, 21));
        public ActionAndBenefitMessage actionAndBenefitMessage2 = new ActionAndBenefitMessage(new Guid("0e90a9a7-2722-45bb-a3de-7832131dcfe3"), "BENU", "2 vitamins Mg for 1 price",  new DateTime(2020, 2, 16), new DateTime(2020, 4, 12));
        public ActionAndBenefitMessage actionAndBenefitMessage3 = new ActionAndBenefitMessage(new Guid("53bfe576-cbfd-4b2e-ab06-8a44be76abad"), "Jankovic", "opis", new DateTime(2020, 12, 3), new DateTime(2020, 12, 11));

        [Fact]
        public void Find_existing_published_message()
        {
            mock = new Mock<IActionsAndBenefitsRepository>();
            mock.Setup(expression: t => t.GetActionAndBenefitMessegeByID(It.IsAny<Guid>())).Returns( new ActionAndBenefitMessage { ActionID = guid, PharmacyName = "Jankovic", Text = "50% off brufen", DateFrom = new DateTime(2020,5,21) ,DateTo = new DateTime(2020,6,21)} );
  
            ActionsAndBenefitsService service = new ActionsAndBenefitsService(mock.Object);
            ActionAndBenefitMessage actionAndBenefitMessage = service.GetActionAndBenefitMessegeByID(guid);

            Assert.NotNull(actionAndBenefitMessage);
        }

        [Fact]
        public void Find_not_existing_published_message()
        {
            mock = new Mock<IActionsAndBenefitsRepository>();
            mock.Setup(expression: t => t.GetAllPublishedActionsAndBenefitsMessages()).Returns(new List<ActionAndBenefitMessage> { actionAndBenefitMessage1});
            ActionsAndBenefitsService service = new ActionsAndBenefitsService(mock.Object);
            ActionAndBenefitMessage actionAndBenefitMessage = service.GetActionAndBenefitMessegeByID(guid2);

            Assert.Null(actionAndBenefitMessage);
        }

        [Fact]
        public void Is_message_already_published()
        {
            ActionsAndBenefitsService service = new ActionsAndBenefitsService();
            bool result = service.IsMessageExisting(actionAndBenefitMessage3);

            Assert.True(result);
        }

        [Fact]
        public void Is_message_not_already_published()
        {
            ActionsAndBenefitsService service = new ActionsAndBenefitsService();
            ActionAndBenefitMessage abmessage = actionAndBenefitMessage2;
            bool result = service.IsMessageExisting(abmessage);

            Assert.False(result);
        }
    }
}
