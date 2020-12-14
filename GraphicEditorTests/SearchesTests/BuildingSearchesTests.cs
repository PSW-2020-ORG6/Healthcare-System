using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class BuildingSearchesTests
    {
        private readonly Building building;
        private readonly List<Building> buildings;

        public BuildingSearchesTests()
        {
            building = new Building("10001", "Cardiology ", "Orange");
            buildings = new List<Building>
            {
                building
            };
        }

        [Fact]
        public void SearchBuildingsByName_BuildingsFound_ReturnBuildings()
        {
            var stubBuildingRepository = new Mock<IBuildingRepository>();
            stubBuildingRepository.Setup(b => b.GetByName(building.Name)).Returns(buildings);

            BuildingService service = new BuildingService(stubBuildingRepository.Object);
            List<Building> foundBuildings = service.GetByName(building.Name);

            Assert.NotEmpty(foundBuildings);
        }

        [Fact]
        public void SearchBuildingsByName_BuildingsNotFound_ReturnEmpty()
        {
            var stubBuildingRepository = new Mock<IBuildingRepository>();
            stubBuildingRepository.Setup(b => b.GetByName("cardusdggbjsd")).Returns(new List<Building>());

            BuildingService service = new BuildingService(stubBuildingRepository.Object);
            List<Building> foundBuildings = service.GetByName("cardusdggbjsd");

            Assert.Empty(foundBuildings);
        }

        [Fact]
        public void SearchAllBuildings_BuildingsFound_ReturnBuilding()
        {
            var stubBuildingRepository = new Mock<IBuildingRepository>();
            stubBuildingRepository.Setup(b => b.GetAll()).Returns(buildings);

            BuildingService service = new BuildingService(stubBuildingRepository.Object);
            List<Building> foundBuildings = service.GetAll();

            Assert.NotEmpty(foundBuildings);
        }

        [Fact]
        public void SearchAllBuildings_BuildingsNotFound_ReturnEmpty()
        {
            var stubBuildingRepository = new Mock<IBuildingRepository>();
            stubBuildingRepository.Setup(b => b.GetAll()).Returns(new List<Building>());

            BuildingService service = new BuildingService(stubBuildingRepository.Object);
            List<Building> foundBuildings = service.GetAll();

            Assert.Empty(foundBuildings);
        }
    }
}