using GraphicEditor.Repositories;
using GraphicEditor.Repositories.Interfaces;
using Xunit;

namespace GraphicEditorTests
{
    public class FloorSearchesTests
    {
        private readonly IFloorRepository _floorRepository;

        public FloorSearchesTests()
        {
            // Arrange
            _floorRepository = new FloorRepository();
        }

        [Fact]
        public void GetFloorsByName_FloorsExist_ReturnFloors()
        {
            // Act
            var floors = _floorRepository.GetFloorsByName("Floor 1");

            // Assert
            Assert.NotNull(floors);
            foreach (var floor in floors)
                Assert.Equal("Floor 1", floor.Name);
        }

        [Fact]
        public void GetFloorsByName_FloorsDontExist_ReturnNull()
        {
            // Act
            var floors = _floorRepository.GetFloorsByName("dkghuskdgfydd");

            // Assert
            Assert.Empty(floors);
        }
    }
}
