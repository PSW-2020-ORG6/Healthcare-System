using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using Xunit;

namespace GraphicEditorTests.RemovalTests
{
    public class RoomRemovalTests
    {
        private readonly Room room;

        public RoomRemovalTests()
        {
            Position position = new Position(1, 1, 1, 1);
            room = new Room("101", "Examination room 101", 101, "1001", "10000001", position, "RoomButtonStyle");
        }

        [Fact]
        public void DestroyRoom_RoomDestroyed_VerifyAction()
        {
            var stubRoomRepository = new Mock<IRoomRepository>();
            stubRoomRepository.Setup(r => r.Delete(It.IsAny<string>()));

            RoomService service = new RoomService(stubRoomRepository.Object);
            service.DeleteRoom(room);

            stubRoomRepository.Verify(r => r.Delete(room.SerialNumber));
        }
    }
}
