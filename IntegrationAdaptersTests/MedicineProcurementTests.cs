using System;
using System.Collections.Generic;
using System.Configuration;
using TenderProcurement;
using TenderProcurement.Models;
using TenderProcurement.Repositories;
using TenderProcurement.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using TenderProcure = TenderProcurement.Models.Tender;

namespace IntegrationAdaptersTests
{
    public class MedicineProcurementTests
    {
        public Mock<IMedicineRepository> mock;
        public Mock<ITenderRepository> mockTender;
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
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<TenderProcure> { new TenderProcure("Tender1", new DateTime(2020, 6, 21),true) });

            TenderService service = new TenderService(mockTender.Object);
            TenderProcure tender = service.GetTenderByName("Tender1");

            Assert.True(tender.IsActive);
        }

        [Fact]
        public void Is_tender_not_active()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<TenderProcure> { new TenderProcure("Tender1", new DateTime(2020, 6, 21), false) });

            TenderService service = new TenderService(mockTender.Object);
            TenderProcure tender = service.GetTenderByName("Tender1");

            Assert.False(tender.IsActive);
        }

        [Fact]
        public void Is_tender_finished()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<TenderProcure> { new TenderProcure("Tender1", new DateTime(2021, 1, 8), false) });

            TenderService service = new TenderService(mockTender.Object);
            TenderProcure tender = service.GetTenderByName("Tender1");

            Assert.True(tender.FinishDate < DateTime.Now);
        }

        [Fact]
        public void Is_tender_not_finished()
        {
            mockTender = new Mock<ITenderRepository>();
            mockTender.Setup(expression: t => t.GetAllTenders()).Returns(new List<TenderProcure> { new TenderProcure("Tender1", new DateTime(2021, 2, 28), false) });

            TenderService service = new TenderService(mockTender.Object);
            TenderProcure tender = service.GetTenderByName("Tender1");

            Assert.True(tender.FinishDate > DateTime.Now);
        }


    }
}
