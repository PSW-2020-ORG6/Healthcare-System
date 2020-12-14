using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class MedicineRepositoryTests
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineRepositoryTests()
        {
            // Arrange
            _medicineRepository = new MedicineDatabaseSql();
        }

        [Fact]
        public void GetMedicineByName_MedicineExists_ReturnMedicine()
        {
            // Act
            var medicine = _medicineRepository.GetByName("Aspirin")[0];

            // Assert
            Assert.NotNull(medicine);
            Assert.Equal("Aspirin", medicine.GenericName);
        }

        [Fact]
        public void GetMedicineByName_MedicineDontExist_ReturnNull()
        {
            // Act
            var medicine = _medicineRepository.GetByName("dkghuskdgfydd");

            // Assert
            Assert.Empty(medicine);
        }

        [Fact]
        public void GetAllMedicine_MedicineExist_ReturnMedicine()
        {
            // Act
            var medicine = _medicineRepository.GetAll();

            // Assert
            Assert.NotEmpty(medicine);
            Assert.NotNull(medicine);
        }
    }
}
