using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using IntegrationAdapters.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using HealthClinicBackend.Backend.Model.Util;
using Xunit;
using System.Collections;

namespace IntegrationAdaptersTests
{
    public class SftpTests
    {
        public Mock<IMedicineReportRepository> Mock = new Mock<IMedicineReportRepository>();

        [SkippableFact]
        public void Sends_files_successfully()
        {
            setEnviroment();
            Skip.IfNot(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development");
            SftpService service = new SftpService();
            bool success = service.SendFile(@"tests/test.txt");
            Assert.True(success);
        }

        [SkippableFact]
        public void Find_existing_report()
        {
            setEnviroment();
            Skip.IfNot(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development");
            Mock.Setup(expression: t => t.GetAll()).Returns(new List<MedicineReport> { new MedicineReport { Id = "1", Date = new DateTime(2020, 10, 5), Dosage = new List<MedicineDosage>() }, new MedicineReport { Id = "2", Date = new DateTime(2020, 5, 10), Dosage = new List<MedicineDosage>() } });

            MedicineReportService service = new MedicineReportService(Mock.Object);
            List<MedicineReport> result = service.GetByDateInterval(new TimeInterval { Start = new DateTime(2020, 5, 10), End = new DateTime(2020, 10, 5) });

            Assert.NotEmpty(result);
        }

        [SkippableFact]
        public void Find_no_existing_report()
        {
            setEnviroment();
            Skip.IfNot(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development");
            Mock.Setup(expression: t => t.GetAll()).Returns(new List<MedicineReport> { new MedicineReport { Id = "1", Date = new DateTime(2020, 10, 5), Dosage = new List<MedicineDosage>() }, new MedicineReport { Id = "2", Date = new DateTime(2020, 5, 10), Dosage = new List<MedicineDosage>() } });

            MedicineReportService service = new MedicineReportService(Mock.Object);
            List<MedicineReport> result = service.GetByDateInterval(new TimeInterval { Start = new DateTime(2020, 6, 10), End = new DateTime(2020, 9, 5) });

            Assert.Empty(result);
        }

        public void setEnviroment()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        }
    }
}