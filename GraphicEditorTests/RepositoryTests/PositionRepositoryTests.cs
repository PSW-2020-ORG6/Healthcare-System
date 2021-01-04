using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class PositionRepositoryTests
    {
        private readonly IPositionRepository _positionRepository;

        public PositionRepositoryTests()
        {
            // Arrange
            _positionRepository = new PositionDatabaseSql();
        }

        [Fact]
        public void GetPositionBySerialNbr_PositionExists_ReturnPosition()
        {
            // Act
            var position = _positionRepository.GetById("70001");

            // Assert
            Assert.NotNull(position);
            Assert.Equal("70001", position.SerialNumber);
        }

        [Fact]
        public void GetPositionBySerialNbr_PositionDoesntExist_ReturnNull()
        {
            // Act
            var position = _positionRepository.GetById("7564335");

            // Assert
            Assert.Null(position);
        }

        [Fact]
        public void GetAllPositions_PositionsExist_ReturnPositions()
        {
            // Act
            var positions = _positionRepository.GetAll();

            // Assert
            Assert.NotEmpty(positions);
            Assert.NotNull(positions);
        }
    }
}

