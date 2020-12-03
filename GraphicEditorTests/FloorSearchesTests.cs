using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;
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
        public void GetFloorByName_FloorExist_ReturnFloor()
        {
            // Act
            var floor = _floorRepository.GetFloorsByName("Floor1")[0];

            // Assert
            Assert.NotNull(floor);
            Assert.Equal("Floor1", floor.Name);
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
