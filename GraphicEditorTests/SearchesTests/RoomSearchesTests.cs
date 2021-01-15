using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class RoomSearchesTests
    {
        private readonly Room room;
        private readonly List<Room> rooms;

        public RoomSearchesTests()
        {
            Position position = new Position(1, 1, 1, 1);
            room = new Room("101", "Examination room 101", 101, "1001", "10000001", position, "RoomButtonStyle");
            rooms = new List<Room>();
            rooms.Add(room);
        }

        [Fact]
        public void SearchRoomsByName_RoomsFound_ReturnRooms()
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            stubRoomRepository.Setup(r => r.GetByName(room.Name)).Returns(rooms);

            RoomService service = new RoomService(stubRoomRepository.Object);
            List<Room> foundRooms = service.GetByName(room.Name);

            Assert.NotEmpty(foundRooms);
        }

        [Fact]
        public void SearchRoomsByName_RoomsNotFound_ReturnEmpty()
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            stubRoomRepository.Setup(r => r.GetByName("exakdr")).Returns(new List<Room>());

            RoomService service = new RoomService(stubRoomRepository.Object);
            List<Room> foundRooms = service.GetByName("exakdr");

            Assert.Empty(foundRooms);
        }

        [Fact]
        public void SearchAllRooms_RoomsFound_ReturnRooms()
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            stubRoomRepository.Setup(r => r.GetAll()).Returns(rooms);

            RoomService service = new RoomService(stubRoomRepository.Object);
            List<Room> foundRooms = service.GetAll();

            Assert.NotEmpty(foundRooms);
        }

        [Fact]
        public void SearchAllRooms_RoomsNotFound_ReturnEmpty()
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            stubRoomRepository.Setup(r => r.GetAll()).Returns(new List<Room>());

            RoomService service = new RoomService(stubRoomRepository.Object);
            List<Room> foundRooms = service.GetAll();

            Assert.Empty(foundRooms);
        }
    }
}
