using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;
using Xunit;

namespace GraphicEditorTests
{
    public class RoomSearchesTests
    {
        private readonly IRoomRepository _roomRepository;

        public RoomSearchesTests()
        {
            // Arrange
            _roomRepository = new RoomRepository();
        }

        [Fact]
        public void GetRoomByName_RoomExist_ReturnRoom()
        {
            // Act
            var room = _roomRepository.GetRoomsByName("Operation room 106")[0];

            // Assert
            Assert.NotNull(room);
            Assert.Equal("Operation room 106", room.Name);
        }

        [Fact]
        public void GetRoomsByName_RoomsDontExist_ReturnNull()
        {
            // Act
            var rooms = _roomRepository.GetRoomsByName("ahagkhdjaf");

            // Assert
            Assert.Empty(rooms);
        }
    }
}
