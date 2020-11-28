using GraphicEditor.Repositories;
using GraphicEditor.Repositories.Interfaces;
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
        public void GetBuildingsByName_BuildingsExist_ReturnBuildings()
        {
            // Act
            var buildings = _buildingRepository.GetBuildingsByName("Cardiology");

            // Assert
            Assert.NotNull(buildings);
            foreach (var building in buildings)
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
