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
        public void GetEquipmentRelocationBySerialNumber_EquipmentRelocationDoesntExist_ReturnNull()
        {
            // Act
            var equipmentRelocation = equipmentRelocationDatabaseSql.GetBySerialNumber("adsadsda");

            // Assert
            Assert.Null(equipmentRelocation);
        }
    }
}
