using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
        public Guid guid = new Guid("0e89a9a7-2722-45bb-a3de-7832131dcfe3");
        public Guid guid2 = new Guid("a69b4d8e-55ce-4cdf-bfa6-7462e085a909");

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
            mock.Setup(expression: t => t.GetAllPublishedActionsAndBenefitsMessages()).Returns(new List<ActionAndBenefitMessage>{
                new ActionAndBenefitMessage { ActionID = guid, PharmacyName = "Jankovic", Text = "50% off brufen", DateFrom = new DateTime(2020, 5, 21), DateTo = new DateTime(2020, 6, 21) }});

            ActionsAndBenefitsService service = new ActionsAndBenefitsService(mock.Object);
            ActionAndBenefitMessage actionAndBenefitMessage = service.GetActionAndBenefitMessegeByID(guid2);

            Assert.Null(actionAndBenefitMessage);
        }

        [Fact]
        public void Is_message_already_published()
        {
            ActionsAndBenefitsService service = new ActionsAndBenefitsService();
            ActionAndBenefitMessage abmessage = new ActionAndBenefitMessage(new Guid("0e65a9a7-2722-45bb-a3de-7832131dcfe3"), "Jankovic", "aspirin 50% off", new DateTime(2020,11,16), new DateTime(2020,4,12));
            bool result = service.IsMessageExisting(abmessage);

            Assert.True(result);
        }

        [Fact]
        public void Is_message_not_already_published()
        {
            ActionsAndBenefitsService service = new ActionsAndBenefitsService();
            ActionAndBenefitMessage abmessage = new ActionAndBenefitMessage(new Guid("0e90a9a7-2722-45bb-a3de-7832131dcfe3"), "Jankovic", "aspirin 50% off", new DateTime(2020, 11, 16), new DateTime(2020, 4, 12));
            bool result = service.IsMessageExisting(abmessage);

            Assert.False(result);
        }

        [Fact]
        public void Find_all_actions_and_benefits()
        {
            mock = new Mock<IActionsAndBenefitsRepository>();
            mock.Setup(expression: t => t.GetAllPublishedActionsAndBenefitsMessages()).Returns(new List<ActionAndBenefitMessage>{
                new ActionAndBenefitMessage { ActionID = guid, PharmacyName = "Jankovic", Text = "50% off brufen", DateFrom = new DateTime(2020, 5, 21), DateTo = new DateTime(2020, 6, 21) }
            ,new ActionAndBenefitMessage { ActionID = new Guid("0e90a9a7-2722-45bb-a3de-7832131dcfe3"), PharmacyName = "BENU",Text = "2 vitamins Mg for 1 price", DateFrom= new DateTime(2020, 2, 16), DateTo = new DateTime(2020, 4, 12)} });

            ActionsAndBenefitsService service = new ActionsAndBenefitsService(mock.Object);
            service.GetAllPublishedActionsAndBenefitsMessages().Count.CompareTo(2);
        }
    }
}
