using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class BuildingRepositoryTests
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingRepositoryTests()
        {
            // Arrange
            _buildingRepository = new BuildingDatabaseSql();
        }

        [Fact]
        public void GetBuildingByName_BuildingExists_ReturnBuilding()
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

        [Fact]
        public void GetAllBuildings_BuildingsExist_ReturnBuildings()
        {
            // Act
            var buildings = _buildingRepository.GetAll();

            // Assert
            Assert.NotEmpty(buildings);
            Assert.NotNull(buildings);
        }
    }
}