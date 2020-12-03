using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;
using Xunit;

namespace GraphicEditorTests
{
    public class BuildingSearchesTests
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingSearchesTests()
        {
            // Arrange
            _buildingRepository = new BuildingRepository();
        }

        [Fact]
        public void GetBuildingByName_BuildingExist_ReturnBuilding()
        {
            // Act
            var building = _buildingRepository.GetBuildingsByName("Cardiology")[0];

            // Assert
            Assert.NotNull(building);
            Assert.Equal("Cardiology", building.Name);
        }

        [Fact]
        public void GetBuildingsByName_BuildingsDontExist_ReturnNull()
        {
            // Act
            var buildings = _buildingRepository.GetBuildingsByName("agfsdgdfhr");

            // Assert
            Assert.Empty(buildings);
        }
    }
}
