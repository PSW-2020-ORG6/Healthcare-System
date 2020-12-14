using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class EquipmentSearchesTests
    {
        private readonly Equipment equipment;
        private readonly List<Equipment> allEquipment;

        public EquipmentSearchesTests()
        {
            equipment = new Equipment("85", "Gloves ", "23");
            allEquipment = new List<Equipment>
            {
                equipment
            };
        }

        [Fact]
        public void SearchEquipmentByName_EquipmentFound_ReturnEquipment()
        {
            var stubEquipmentRepository = new Mock<IEquipmentRepository>();
            stubEquipmentRepository.Setup(e => e.GetByName(equipment.Name)).Returns(allEquipment);

            EquipmentService service = new EquipmentService(stubEquipmentRepository.Object);
            List<Equipment> foundEquipment = service.GetByName(equipment.Name);

            Assert.NotEmpty(foundEquipment);
        }

        [Fact]
        public void SearchEquipmentByName_EquipmentNotFound_ReturnEmpty()
        {
            var stubEquipmentRepository = new Mock<IEquipmentRepository>();
            stubEquipmentRepository.Setup(e => e.GetByName("glogfre")).Returns(new List<Equipment>());

            EquipmentService service = new EquipmentService(stubEquipmentRepository.Object);
            List<Equipment> foundEquipment = service.GetByName("glogfre");

            Assert.Empty(foundEquipment);
        }

        [Fact]
        public void SearchAllEquipment_EquipmentFound_ReturnEquipment()
        {
            var stubEquipmentRepository = new Mock<IEquipmentRepository>();
            stubEquipmentRepository.Setup(e => e.GetAll()).Returns(allEquipment);

            EquipmentService service = new EquipmentService(stubEquipmentRepository.Object);
            List<Equipment> foundEquipment = service.GetAll();

            Assert.NotEmpty(foundEquipment);
        }

        [Fact]
        public void SearchAllEquipment_EquipmentNotFound_ReturnEmpty()
        {
            var stubEquipmentRepository = new Mock<IEquipmentRepository>();
            stubEquipmentRepository.Setup(e => e.GetAll()).Returns(new List<Equipment>());

            EquipmentService service = new EquipmentService(stubEquipmentRepository.Object);
            List<Equipment> foundEquipment = service.GetAll();

            Assert.Empty(foundEquipment);
        }
    }
}