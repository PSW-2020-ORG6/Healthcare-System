using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class FloorSearchesTests
    {
        private readonly Floor floor;
        private readonly List<Floor> floors;

        public FloorSearchesTests()
        {
            floor = new Floor("1001", "Floor1 ", "10001");
            floors = new List<Floor>
            {
                floor
            };
        }

        [Fact]
        public void SearchFloorsByName_FloorsFound_ReturnFloors()
        {
            var stubFloorRepository = new Mock<IFloorRepository>();
            stubFloorRepository.Setup(f => f.GetByName(floor.Name)).Returns(floors);

            FloorService service = new FloorService(stubFloorRepository.Object);
            List<Floor> foundFloors = service.GetByName(floor.Name);

            Assert.NotEmpty(foundFloors);
        }

        [Fact]
        public void SearchFloorsByName_FloorsNotFound_ReturnEmpty()
        {
            var stubFloorRepository = new Mock<IFloorRepository>();
            stubFloorRepository.Setup(f => f.GetByName("florwre")).Returns(new List<Floor>());

            FloorService service = new FloorService(stubFloorRepository.Object);
            List<Floor> foundFloors = service.GetByName("florwre");

            Assert.Empty(foundFloors);
        }

        [Fact]
        public void SearchAllFloors_FloorsFound_ReturnFloors()
        {
            var stubFloorRepository = new Mock<IFloorRepository>();
            stubFloorRepository.Setup(f => f.GetAll()).Returns(floors);

            FloorService service = new FloorService(stubFloorRepository.Object);
            List<Floor> foundFloors = service.GetAll();

            Assert.NotEmpty(foundFloors);
        }

        [Fact]
        public void SearchAllFloors_FloorsNotFound_ReturnEmpty()
        {
            var stubFloorRepository = new Mock<IFloorRepository>();
            stubFloorRepository.Setup(f => f.GetAll()).Returns(new List<Floor>());

            FloorService service = new FloorService(stubFloorRepository.Object);
            List<Floor> foundFloors = service.GetAll();

            Assert.Empty(foundFloors);
        }
    }
}
