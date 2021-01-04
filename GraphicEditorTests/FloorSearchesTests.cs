using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class FloorSearchesTests
    {
        private readonly IFloorRepository _floorRepository;

        public FloorSearchesTests()
        {
            // Arrange
            _floorRepository = new FloorDatabaseSql();
        }

        [Fact]
        public void GetFloorByName_FloorExist_ReturnFloor()
        {
            // Act
            var floor = _floorRepository.GetByName("Floor1")[0];

            // Assert
            Assert.NotNull(floor);
            Assert.Equal("Floor1", floor.Name);
        }

        [Fact]
        public void GetFloorsByName_FloorsDontExist_ReturnNull()
        {
            // Act
            var floors = _floorRepository.GetByName("dkghuskdgfydd");

            // Assert
            Assert.Empty(floors);
        }
    }
}