using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using Xunit;

namespace GraphicEditorTests.RemovalTests
{
    public class EquipmentRemovalTests
    {
        private readonly Equipment equipment;

        public EquipmentRemovalTests()
        {
            equipment = new Equipment("85", "Gloves ", "23");
        }

        [Fact]
        public void RemoveEquipment_EquipmentRemoved_VerifyAction()
        {
            var stubEquipmentRepository = new Mock<IEquipmentRepository>();
            stubEquipmentRepository.Setup(e => e.Delete(It.IsAny<string>()));

            EquipmentService service = new EquipmentService(stubEquipmentRepository.Object);
            service.DeleteEquipment(equipment);

            stubEquipmentRepository.Verify(e => e.Delete(equipment.SerialNumber));
        }
    }
}
