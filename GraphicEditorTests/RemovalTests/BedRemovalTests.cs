using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using Xunit;

namespace GraphicEditorTests.RemovalTests
{
    public class BedRemovalTests
    {
        private readonly Bed bed;

        public BedRemovalTests()
        {
            bed = new Bed("100001", "Bed 1", "100001");
        }

        [Fact]
        public void RemoveBed_BedRemoved_VerifyAction()
        {
            var stubBedRepository = new Mock<IBedRepository>();
            stubBedRepository.Setup(b => b.Delete(It.IsAny<string>()));

            BedService service = new BedService(stubBedRepository.Object);
            service.DeleteBed(bed);

            stubBedRepository.Verify(b => b.Delete(bed.SerialNumber));
        }
    }
}
