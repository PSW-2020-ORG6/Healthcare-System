using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.MedicineService;
using Moq;
using Xunit;


namespace GraphicEditorTests.RemovalTests
{
    public class MedicineRemovalTests
    {
        private readonly Medicine medicine;

        public MedicineRemovalTests()
        {
            medicine = new Medicine("21", "Brufen", "Brufen", true, "1", "11", "101");
        }

        [Fact]
        public void RemoveApprovedMedicine_ApprovedMedicineRemoved_VerifyAction()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.Delete(It.IsAny<string>()));

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            service.DeleteApprovedMedicine(medicine);

            stubMedicineRepository.Verify(m => m.Delete(medicine.SerialNumber));
        }

        [Fact]
        public void RemoveWaitingMedicine_WaitingMedicineRemoved_VerifyAction()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            stubMedicineRepository.Setup(m => m.Delete(It.IsAny<string>()));

            SuperintendentMedicineService service = new SuperintendentMedicineService(stubMedicineRepository.Object);
            service.DeleteWaitingMedicine(medicine);

            stubMedicineRepository.Verify(m => m.Delete(medicine.SerialNumber));
        }
    }
}
