using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using IntegrationAdapters.Services;
using Model.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class SftpTests
    {
        public Mock<IMedicineReportRepository> mock;
        [Fact]
        public void sendFileSuccess()
        {  
            SftpService service = new SftpService();
            bool success = service.SendFile(@"C:\Users\dragana\Desktop\Projekat PSW\Healthcare-System\IntegrationAdaptersTests\bin\Debug\netcoreapp3.1\testFile.txt");
            Assert.True(success);   
        }

        [Fact]
        public void Find_existing_report()
        {
            mock = new Mock<IMedicineReportRepository>();
            mock.Setup(expression: t => t.GetAll()).Returns(new List<MedicineReport> { new MedicineReport { Id = "1", Date = new DateTime(2020, 10, 5), Dosage = new List<MedicineDosage>() }, new MedicineReport { Id = "2", Date = new DateTime(2020, 5, 10), Dosage = new List<MedicineDosage>() } });

            MedicineReportService service = new MedicineReportService();
            List<MedicineReport> result = service.GetByDateInterval(mock.Object.GetAll(), new TimeInterval { Start = new DateTime(2020, 5, 10), End = new DateTime(2020, 10, 5) });

            Assert.NotEmpty(result);
        }

        [Fact]
        public void Find_no_existing_report()
        {
            mock = new Mock<IMedicineReportRepository>();
            mock.Setup(expression: t => t.GetAll()).Returns(new List<MedicineReport> { new MedicineReport { Id = "1", Date = new DateTime(2020, 10, 5), Dosage = new List<MedicineDosage>() }, new MedicineReport { Id = "2", Date = new DateTime(2020, 5, 10), Dosage = new List<MedicineDosage>() } });

            MedicineReportService service = new MedicineReportService();
            List<MedicineReport> result = service.GetByDateInterval(mock.Object.GetAll(), new TimeInterval { Start = new DateTime(2020, 6, 10), End = new DateTime(2020, 9, 5) });

            Assert.Empty(result);
        }
    }
}
