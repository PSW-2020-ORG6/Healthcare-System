using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class RoomSearchesTests
    {
        private readonly IRoomRepository _roomRepository;

        public RoomSearchesTests()
        {
            // Arrange
            _roomRepository = new RoomDatabaseSql();
        }

        [Fact]
        public void GetRoomByName_RoomExist_ReturnRoom()
        {
            // Act
            var room = _roomRepository.GetByName("Operation room 106")[0];

            // Assert
            Assert.NotNull(room);
            Assert.Equal("Operation room 106", room.Name);
        }

        [Fact]
        public void GetRoomsByName_RoomsDontExist_ReturnNull()
        {
            // Act
            var rooms = _roomRepository.GetByName("ahagkhdjaf");

            // Assert
            Assert.Empty(rooms);
        }
    }
}