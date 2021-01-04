using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests.SearchesTests
{
    public class PositionSearchesTests
    {
        private readonly Position position;
        private readonly List<Position> positions;

        public PositionSearchesTests()
        {
            position = new Position("70001", 1, 1, 1, 1);
            positions = new List<Position>
            {
                position
            };
        }

        [Fact]
        public void SearchPositionBySerialNbr_PositionFound_ReturnPosition()
        {
            var stubPositionRepository = new Mock<IPositionRepository>();
            stubPositionRepository.Setup(p => p.GetById(position.SerialNumber))
                .Returns(position);

            PositionService service = new PositionService(stubPositionRepository.Object);
            Position foundPosition = service.GetById(position.SerialNumber);

            Assert.NotNull(foundPosition);
        }

        [Fact]
        public void SearchPositionBySerialNbr_PositionNotFound_ReturnPositionWithZeroValues()
        {
            var stubPositionRepository = new Mock<IPositionRepository>();
            stubPositionRepository.Setup(p => p.GetById("posigjd324")).Returns(new Position());

            PositionService service = new PositionService(stubPositionRepository.Object);
            Position foundPosition = service.GetById("posigjd324");

            Assert.Equal(0, foundPosition.Row);
            Assert.Equal(0, foundPosition.Column);
            Assert.Equal(0, foundPosition.RowSpan);
            Assert.Equal(0, foundPosition.ColumnSpan);
        }

        [Fact]
        public void SearchAllPositionsBySerialNbrs_PositionsFound_ReturnPositions()
        {
            var stubPositionRepository = new Mock<IPositionRepository>();
            stubPositionRepository.Setup(p => p.GetAll()).Returns(positions);

            PositionService service = new PositionService(stubPositionRepository.Object);
            List<Position> foundPositions = service.GetAll();

            Assert.NotEmpty(foundPositions);
        }

        [Fact]
        public void SearchAllPositions_PositionsNotFound_ReturnEmpty()
        {
            var stubPositionRepository = new Mock<IPositionRepository>();
            stubPositionRepository.Setup(p => p.GetAll()).Returns(new List<Position>());

            PositionService service = new PositionService(stubPositionRepository.Object);
            List<Position> foundPositions = service.GetAll();

            Assert.Empty(foundPositions);
        }
    }
}
