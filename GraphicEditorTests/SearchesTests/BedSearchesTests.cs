using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests.SearchesTests
{
    public class BedSearchesTests
    {
        private readonly Bed bed;
        private readonly List<Bed> beds;

        public BedSearchesTests()
        {
            bed = new Bed("100001", "Bed 1", "100001");
            beds = new List<Bed>
            {
                bed
            };
        }

        [Fact]
        public void SearchBedsByName_BedsFound_ReturnBeds()
        {
            var stubBedRepository = new Mock<IBedRepository>();
            stubBedRepository.Setup(b => b.GetByName(bed.Name)).Returns(beds);

            BedService service = new BedService(stubBedRepository.Object);
            List<Bed> foundBeds = service.GetByName(bed.Name);

            Assert.NotEmpty(foundBeds);
        }

        [Fact]
        public void SearchBedsByName_BedsNotFound_ReturnEmpty()
        {
            var stubBedRepository = new Mock<IBedRepository>();
            stubBedRepository.Setup(b => b.GetByName("exakdr")).Returns(new List<Bed>());

            BedService service = new BedService(stubBedRepository.Object);
            List<Bed> foundBeds = service.GetByName("exakdr");

            Assert.Empty(foundBeds);
        }

        [Fact]
        public void SearchAllBeds_BedsFound_ReturnBeds()
        {
            var stubBedRepository = new Mock<IBedRepository>();
            stubBedRepository.Setup(b => b.GetAll()).Returns(beds);

            BedService service = new BedService(stubBedRepository.Object);
            List<Bed> foundBeds = service.GetAll();

            Assert.NotEmpty(foundBeds);
        }

        [Fact]
        public void SearchAllBeds_BedsNotFound_ReturnEmpty()
        {
            var stubBedRepository = new Mock<IBedRepository>();
            stubBedRepository.Setup(b => b.GetAll()).Returns(new List<Bed>());

            BedService service = new BedService(stubBedRepository.Object);
            List<Bed> foundBeds = service.GetAll();

            Assert.Empty(foundBeds);
        }
    }
}
