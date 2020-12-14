using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class BedRepositoryTests
    {
        private readonly IBedRepository _bedRepository;

        public BedRepositoryTests()
        {
            // Arrange
            _bedRepository = new BedDatabaseSql();
        }

        [Fact]
        public void GetBedByName_BedExists_ReturnBed()
        {
            // Act
            var bed = _bedRepository.GetByName("Bed 1")[0];

            // Assert
            Assert.NotNull(bed);
            Assert.Equal("Bed 1", bed.Name);
        }

        [Fact]
        public void GetBedsByName_BedsDontExist_ReturnNull()
        {
            // Act
            var beds = _bedRepository.GetByName("behdj");

            // Assert
            Assert.Empty(beds);
        }

        [Fact]
        public void GetAllBeds_BedsExist_ReturnBeds()
        {
            // Act
            var beds = _bedRepository.GetAll();

            // Assert
            Assert.NotEmpty(beds);
            Assert.NotNull(beds);
        }
    }
}
