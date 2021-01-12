using System;
using System.Collections.Generic;
using System.Configuration;
using IntegrationAdapters;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using IntegrationAdapters.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class MedicineProcurementTests
    {
        public Mock<IMedicineRepository> mock;
        public Mock<ITenderRepository> mockTender;
        public TenderOffer tenderOffer1 = new TenderOffer("40", "knezevicljiljana12@gmail.com", "Fakultet thenickih nauka", "tender02", "Aspirin", 100, 20);
        public TenderOffer tenderOffer2 = new TenderOffer("2", "mili@gmail.com", "Benu apoteka", "tender02", "Brufen", 70, 120);


        [Fact]
        public void Find_existing_offer()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetOfferById(It.IsAny<String>())).Returns(new TenderOffer { Id = "40", CompanyEmail = "knezevicljiljana12@gmail.com", CompanyName = "Fakultet thenickih nauka", TenderName = "tender02", Quantity = 100, Price = 20 });
            TenderService service = new TenderService(mockTender.Object);
            TenderOffer tenderOffer = service.GetOfferById("40");

            Assert.NotNull(tenderOffer);
        }
        [Fact]
        public void Find_not_existing_offer()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllOffers()).Returns(new List<TenderOffer> { tenderOffer1 });
            TenderService service = new TenderService(mockTender.Object);
            TenderOffer tenderOffer = service.GetOfferById("34");

            Assert.Null(tenderOffer);
        }
        [Fact]
        public void Is_offer_not_already_send()
        {
            TenderService service = new TenderService();
            bool result = service.IsOfferExisting(tenderOffer2);

            Assert.False(result);
        }

        [Fact]
        public void Is_offer_already_send()
        {
            TenderService service = new TenderService();
            bool result = service.IsOfferExisting(tenderOffer1);

            Assert.True(result);
        }
        [Fact]
        public void Does_medicine_exist()
        {
            mock = new Mock<IMedicineRepository>();
            mock.Setup(expression: t => t.GetAll()).Returns(new List<Medicine> { new Medicine("123","Aspirin","25",5)});

            MedicineService service = new MedicineService(mock.Object);
            Medicine medicine = service.GetByID("123");

            Assert.NotNull(medicine);
        }

        [Fact]
        public void Does_not_medicine_exist()
        {
            mock = new Mock<IMedicineRepository>();
            mock.Setup(expression: t => t.GetAll()).Returns(new List<Medicine> { new Medicine("123", "Aspirin", "25", 5) });

            MedicineService service = new MedicineService(mock.Object);
            Medicine medicine = service.GetByID("1235");

            Assert.Null(medicine);
        }

        [Fact]
        public void Is_tender_active()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<Tender> { new Tender("Tender1", new DateTime(2020, 6, 21),true) });

            TenderService service = new TenderService(mockTender.Object);
            Tender tender = service.GetTenderByName("Tender1");

            Assert.True(tender.IsActive);
        }

        [Fact]
        public void Is_tender_not_active()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<Tender> { new Tender("Tender1", new DateTime(2020, 6, 21), false) });

            TenderService service = new TenderService(mockTender.Object);
            Tender tender = service.GetTenderByName("Tender1");

            Assert.False(tender.IsActive);
        }

        [Fact]
        public void Is_tender_finished()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<Tender> { new Tender("Tender1", new DateTime(2021, 1, 8), false) });

            TenderService service = new TenderService(mockTender.Object);
            Tender tender = service.GetTenderByName("Tender1");

            Assert.True(tender.FinishDate < DateTime.Now);
        }

        [Fact]
        public void Is_tender_not_finished()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<Tender> { new Tender("Tender1", new DateTime(2021, 2, 28), false) });

            TenderService service = new TenderService(mockTender.Object);
            Tender tender = service.GetTenderByName("Tender1");

            Assert.True(tender.FinishDate > DateTime.Now);
        }


    }
}
