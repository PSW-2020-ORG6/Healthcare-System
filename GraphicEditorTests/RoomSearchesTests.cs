using GraphicEditor.Repositories;
using GraphicEditor.Repositories.Interfaces;
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
        public void GetRoomsByName_RoomsExist_ReturnRooms()
        {
            // Act
            var rooms = _roomRepository.GetRoomsByName("Operation room");

            // Assert
            Assert.NotNull(rooms);
            foreach (var room in rooms)
                Assert.Equal("Operation room", room.Name);
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
