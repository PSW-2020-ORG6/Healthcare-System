using System;
using System.Collections.Generic;
using System.Text;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class EquipmentSearchesTests
    {
        private readonly IEquipmentRepository _eqipmentRepository;

        public EquipmentSearchesTests()
        {
            _eqipmentRepository = new EquipmentDatabaseSql();
        }

        [Fact]
        public void GetEquipmentByName_EquipmentExist_ReturnEquipment()
        {
            //Act
            var equipment = _eqipmentRepository.GetByName("Bed 1")[0];

            //Assert
            Assert.NotNull(equipment);
            Assert.Equal("Bed 1", equipment.Name);
        }

        [Fact]
        public void EquipmentDoesNotExist()
        {
            //Act
            var equipments = _eqipmentRepository.GetByName("pera");

            //Assert
            Assert.Empty(equipments);
        }
    }
}