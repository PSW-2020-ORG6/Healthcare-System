using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.MedicineService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class MedicineSearchesTests
    {
        private readonly Medicine medicine;
        private readonly List<Medicine> allMedicine;

        public MedicineSearchesTests()
        {
            medicine = new Medicine("21", "Brufen", "Brufen", true, "1", "11", "101");
            allMedicine = new List<Medicine>
            {
                medicine
            };
        }

        [Fact]
        public void SuperintendentSearchMedicineByGenericName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName(medicine.GenericName)).Returns(allMedicine);

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName(medicine.GenericName);

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void SuperintendentSearchMedicineByGenericName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName("asppdpfd")).Returns(new List<Medicine>());

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName("asppdpfd");

            Assert.Empty(foundMedicine);
        }

        [Fact]
        public void SuperintendentSearchMedicineByCopyrightName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName(medicine.CopyrightName)).Returns(allMedicine);

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName(medicine.CopyrightName);

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void SuperintendentSearchMedicineByCopyrightName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName("asfhgf")).Returns(new List<Medicine>());

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName("asfhgf");

            Assert.Empty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchMedicineByGenericName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName(medicine.GenericName)).Returns(allMedicine);

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName(medicine.GenericName);

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchMedicineByGenericName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName("ashrth")).Returns(new List<Medicine>());

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName("ashrth");

            Assert.Empty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchMedicineByCopyrightName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName(medicine.CopyrightName)).Returns(allMedicine);

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName(medicine.CopyrightName);

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchMedicineByCopyrightName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetByName("asfhgf")).Returns(new List<Medicine>());

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetByName("asfhgf");

            Assert.Empty(foundMedicine);
        }

        [Fact]
        public void SuperintendentSearchAllMedicineByGenericName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(allMedicine);

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void SuperintendentSearchAllMedicineByGenericName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(new List<Medicine>());

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.Empty(foundMedicine);
        }

        [Fact]
        public void SuperintendentSearchAllMedicineByCopyrightName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(allMedicine);

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void SuperintendentSearchAllMedicineByCopyrightName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(new List<Medicine>());

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.Empty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchAllMedicineByGenericName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(allMedicine);

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchAllMedicineByGenericName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(new List<Medicine>());

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.Empty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchAllMedicineByCopyrightName_MedicineFound_ReturnMedicine()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(allMedicine);

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.NotEmpty(foundMedicine);
        }

        [Fact]
        public void PhysicianSearchAllMedicineByCopyrightName_MedicineNotFound_ReturnEmpty()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.GetAll()).Returns(new List<Medicine>());

            PhysicianMedicineService service = new PhysicianMedicineService(stubMedicineRepository.Object);
            List<Medicine> foundMedicine = service.GetAll();

            Assert.Empty(foundMedicine);
        }
    }
}