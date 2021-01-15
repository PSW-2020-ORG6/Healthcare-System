using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.SchedulingService;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests.SearchesTests
{
    public class EquipmentRelocationSearchesTests
    {
        private readonly EquipmentRelocation equipmentRelocation;
        private readonly List<EquipmentRelocation> equipmentRelocations;

        public EquipmentRelocationSearchesTests()
        {
            Equipment equipment = new Equipment("80", "Table", "18");
            equipmentRelocation = new EquipmentRelocation(DateTime.Now, DateTime.Now, equipment, "101", 3);
            equipmentRelocations = new List<EquipmentRelocation>
            {
                equipmentRelocation
            };
        }

        [Fact]
        public void SearchEquipmentRelocationBySerialNbr_EquipmentRelocationFound_ReturnEquipmentRelocation()
        {
            var stubEquipmentRelocationRepository = new Mock<IEquipmentRelocationDatabaseSql>();
            stubEquipmentRelocationRepository.Setup(er => er.GetBySerialNumber(equipmentRelocation.SerialNumber))
                .Returns(equipmentRelocation);

            EquipmentRelocationService service = new EquipmentRelocationService(stubEquipmentRelocationRepository.Object);
            EquipmentRelocation foundEquipmentRelocation = service.GetBySerialNumber(equipmentRelocation.SerialNumber);

            Assert.NotNull(foundEquipmentRelocation);
        }

        [Fact]
        public void SearchEquipmentRelocationBySerialNbr_EquipmentRelocationNotFound_ReturnNull()
        {
            var stubEquipmentRelocationRepository = new Mock<IEquipmentRelocationDatabaseSql>();
            stubEquipmentRelocationRepository.Setup(er => er.GetBySerialNumber("80805463456546"))
                .Returns(new EquipmentRelocation());

            EquipmentRelocationService service = new EquipmentRelocationService(stubEquipmentRelocationRepository.Object);
            EquipmentRelocation foundEquipmentRelocation = service.GetBySerialNumber("80805463456546");

            Assert.Null(foundEquipmentRelocation.equipment);
            Assert.Null(foundEquipmentRelocation.equipmentSerialNumber);
            Assert.Equal(0, (double)foundEquipmentRelocation.quantity);
            Assert.Null(foundEquipmentRelocation.roomToRelocateTo);
            Assert.Null(foundEquipmentRelocation.roomToRelocateToSerialNumber);
            Assert.Null(foundEquipmentRelocation.TimeInterval);
        }

        [Fact]
        public void SearchAllEquipmentRelocations_EquipmentRelocationsFound_ReturnEquipmentRelocations()
        {
            var stubEquipmentRelocationRepository = new Mock<IEquipmentRelocationDatabaseSql>();
            stubEquipmentRelocationRepository.Setup(er => er.GetAll()).Returns(equipmentRelocations);

            EquipmentRelocationService service = new EquipmentRelocationService(stubEquipmentRelocationRepository.Object);
            List<EquipmentRelocation> foundEquipmentRelocations = service.GetAll();

            Assert.NotEmpty(foundEquipmentRelocations);
        }

        [Fact]
        public void SearchAllEquipmentRelocations_EquipmentRelocationsNotFound_ReturnEmpty()
        {
            var stubEquipmentRelocationRepository = new Mock<IEquipmentRelocationDatabaseSql>();
            stubEquipmentRelocationRepository.Setup(er => er.GetAll()).Returns(new List<EquipmentRelocation>());

            EquipmentRelocationService service = new EquipmentRelocationService(stubEquipmentRelocationRepository.Object);
            List<EquipmentRelocation> foundEquipmentRelocations = service.GetAll();

            Assert.Empty(foundEquipmentRelocations);
        }
    }
}
