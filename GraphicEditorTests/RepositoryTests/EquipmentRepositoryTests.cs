using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class EquipmentRepositoryTests
    {
        private readonly IEquipmentRepository _eqipmentRepository;

        public EquipmentRepositoryTests()
        {
            _eqipmentRepository = new EquipmentDatabaseSql();
        }

        [Fact]
        public void GetEquipmentByName_EquipmentExists_ReturnEquipment()
        {
            //Act
            var equipment = _eqipmentRepository.GetByName("Mask")[0];

            //Assert
            Assert.NotNull(equipment);
            Assert.Equal("Mask", equipment.Name);
        }

        [Fact]
        public void GetEquipmentByName_EquipmentDontExist_ReturnNull()
        {
            //Act
            var equipment = _eqipmentRepository.GetByName("Massss");

            //Assert
            Assert.Empty(equipment);
        }

        [Fact]
        public void GetAllEquipment_EquipmentExist_ReturnEquipment()
        {
            // Act
            var equipment = _eqipmentRepository.GetAll();

            // Assert
            Assert.NotEmpty(equipment);
            Assert.NotNull(equipment);
        }
    }
}
