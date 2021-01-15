using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using Xunit;

namespace GraphicEditorTests.RemovalTests
{
    public class FloorRemovalTests
    {
        private readonly Floor floor;

        public FloorRemovalTests()
        {
            floor = new Floor("1001", "Floor1 ", "10001");
        }

        [Fact]
        public void RemoveFloor_FloorRemoved_VerifyAction()
        {
            var stubFloorRepository = new Mock<IFloorRepository>();
            stubFloorRepository.Setup(f => f.Delete(It.IsAny<string>()));

            FloorService service = new FloorService(stubFloorRepository.Object);
            service.DeleteFloor(floor);

            stubFloorRepository.Verify(f => f.Delete(floor.SerialNumber));
        }
    }
}
