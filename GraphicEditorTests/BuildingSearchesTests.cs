using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class BuildingSearchesTests
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingSearchesTests()
        {
            // Arrange
            _buildingRepository = new BuildingDatabaseSql();
        }

        [Fact]
        public void GetBuildingByName_BuildingExist_ReturnBuilding()
        {
            // Act
            var building = _buildingRepository.GetByName("Cardiology")[0];

            // Assert
            Assert.NotNull(building);
            Assert.Equal("Cardiology", building.Name);
        }

        [Fact]
        public void GetBuildingsByName_BuildingsDontExist_ReturnNull()
        {
            // Act
            var buildings = _buildingRepository.GetByName("agfsdgdfhr");

            // Assert
            Assert.Empty(buildings);
        }
    }
}