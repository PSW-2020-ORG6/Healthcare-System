using System;
using System.Collections.Generic;
using System.Text;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using IntegrationAdapters.Services;
using Moq;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class MedicineTests
    {
        public Mock<IMedicineRepository> mock;
        public Medicine medicine1 = new Medicine("1", "Brufen", "1");
        public Medicine medicine2 = new Medicine("2", "Aspirin", "2");
        public Medicine medicine3 = new Medicine("6", "Aspirin", "2");
        public MedicineSpecification medicinespecifation = new MedicineSpecification("1", "content", "type", "shape", "notes", "regime", "producer", new List<string> { "replacement1" });

        [Fact]
        public void Find_existing_medicine()
        {
            mock = new Mock<IMedicineRepository>();
            mock.Setup(expression: t => t.GetAll()).Returns(new List<Medicine> { medicine1,medicine2});

            MedicineService service = new MedicineService(mock.Object);
            Medicine med = service.GetByID("1");

            Assert.NotNull(med);
        }
        [Fact]
        public void Find_not_existing_medicine()
        {
            mock = new Mock<IMedicineRepository>();
            mock.Setup(expression: t => t.GetAll()).Returns(new List<Medicine> { medicine1, medicine2 });

            MedicineService service = new MedicineService(mock.Object);
            Medicine med = service.GetByID("3");

            Assert.Null(med);
        }

        [Fact]
        public void Find_existing_medicine_specification()
        {
            mock = new Mock<IMedicineRepository>();
            mock.Setup(expression: t => t.GetAllSpecifications()).Returns(new List<MedicineSpecification> { medicinespecifation });

            MedicineService service = new MedicineService(mock.Object);
            MedicineSpecification spec = service.GetById("1");

            Assert.NotNull(spec);
        }

        [Fact]
        public void Find_not_existing_medicine_specification()
        {
            mock = new Mock<IMedicineRepository>();
            mock.Setup(expression: t => t.GetAllSpecifications()).Returns(new List<MedicineSpecification> { medicinespecifation });

            MedicineService service = new MedicineService(mock.Object);
            MedicineSpecification spec = service.GetById("2");

            Assert.Null(spec);
        }

        [Fact]
        public void Does_medicine_exist()
        {
            MedicineService service = new MedicineService();

            bool result = service.DoesMedicineExist(medicine1);

            Assert.True(result);
        }
        [Fact]
        public void Does_medicine_not_exist()
        {
            MedicineService service = new MedicineService();

            bool result = service.DoesMedicineExist(medicine3);

            Assert.False(result);
        }
    }
}
