using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class FloorRepositoryTests
    {
        private readonly IFloorRepository _floorRepository;

        public FloorRepositoryTests()
        {
            // Arrange
            _floorRepository = new FloorDatabaseSql();
        }

        [Fact]
        public void GetFloorByName_FloorExists_ReturnFloor()
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

        [Fact]
        public void GetAllFloors_FloorsExist_ReturnFloors()
        {
            // Act
            var floors = _floorRepository.GetAll();

            // Assert
            Assert.NotEmpty(floors);
            Assert.NotNull(floors);
        }
    }
}