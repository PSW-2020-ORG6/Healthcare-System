using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using Xunit;

namespace GraphicEditorTests.RemovalTests
{
    public class BuildingRemovalTests
    {
        private readonly Building building;

        public BuildingRemovalTests()
        {
            building = new Building("10001", "Cardiology ", "Orange");
        }

        [Fact]
        public void DestroyBuilding_BuildingDestroyed_VerifyAction()
        {
            var stubBuildingRepository = new Mock<IBuildingRepository>();
            stubBuildingRepository.Setup(b => b.Delete(It.IsAny<string>()));

            BuildingService service = new BuildingService(stubBuildingRepository.Object);
            service.DeleteBuilding(building);

            stubBuildingRepository.Verify(b => b.Delete(building.SerialNumber));
        }
    }
}
