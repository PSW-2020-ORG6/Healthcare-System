using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphicEditorTests
{
    public class EquipmentSearchesTests
    {
        private readonly IEquipmentRepository _eqipmentRepository;

        public EquipmentSearchesTests()
        {
            _eqipmentRepository = new EquipmentRepository();
        }

        [Fact]
        public void GetEquipmentByName_EquipmentExist_ReturnEquipment()
        {
            //Act
            var equipment = _eqipmentRepository.GetEquipmentsByName("Bed 1")[0];

            //Assert
            Assert.NotNull(equipment);
            Assert.Equal("Bed 1", equipment.Name);
        }

        [Fact]
        public void EquipmentDoesNotExist()
        {
            //Act
            var equipments = _eqipmentRepository.GetEquipmentsByName("pera");

            //Assert
            Assert.Empty(equipments);
        }
    }
}
