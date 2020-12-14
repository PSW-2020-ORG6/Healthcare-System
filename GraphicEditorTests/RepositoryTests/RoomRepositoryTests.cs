using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class RoomRepositoryTests
    {
        private readonly IRoomRepository _roomRepository;

        public RoomRepositoryTests()
        {
            // Arrange
            _roomRepository = new RoomDatabaseSql();
        }

        [Fact]
        public void GetRoomByName_RoomExists_ReturnRoom()
        {
            // Act
            var room = _roomRepository.GetByName("Examination room 101")[0];

            // Assert
            Assert.NotNull(room);
            Assert.Equal("Examination room 101", room.Name);
        }

        [Fact]
        public void GetRoomsByName_RoomsDontExist_ReturnNull()
        {
            // Act
            var rooms = _roomRepository.GetByName("ahagkhdjaf");

            // Assert
            Assert.Empty(rooms);
        }

        [Fact]
        public void GetAllRooms_RoomsExist_ReturnRooms()
        {
            // Act
            var rooms = _roomRepository.GetAll();

            // Assert
            Assert.NotEmpty(rooms);
            Assert.NotNull(rooms);
        }
    }
}
