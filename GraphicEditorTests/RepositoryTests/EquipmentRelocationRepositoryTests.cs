using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class EquipmentRelocationRepositoryTests
    {
        private readonly IEquipmentRelocationDatabaseSql equipmentRelocationDatabaseSql;

        public EquipmentRelocationRepositoryTests()
        {
            equipmentRelocationDatabaseSql = new EquipmentRelocationDatabaseSql();
        }
        [Fact]
        public void GetEquipmentRelocationBySerialNumber_EquipmenRelocationExists_ReturnIt()
        {
            //Act
            var equipmentRelocation = equipmentRelocationDatabaseSql.GetBySerialNumber("ER1");

            //Assert
            Assert.NotNull(equipmentRelocation);
            Assert.Equal("ER1", equipmentRelocation.SerialNumber);
        }
        [Fact]
        public void GetEquipmentRelocationBySerialNumber_EquipmentRelocationDoesntExist_ReturnNull()
        {
            // Act
            var equipmentRelocation = equipmentRelocationDatabaseSql.GetBySerialNumber("adsadsda");

            // Assert
            Assert.Null(equipmentRelocation);
        }

        [Fact]
        public void GetAllEquipmentRelocations_EquipmentRelocationsExist_ReturnAppointments()
        {
            // Act
            var equipmentRelocation = equipmentRelocationDatabaseSql.GetAll();

            // Assert
            Assert.NotEmpty(equipmentRelocation);
            Assert.NotNull(equipmentRelocation);
        }
    }
}
