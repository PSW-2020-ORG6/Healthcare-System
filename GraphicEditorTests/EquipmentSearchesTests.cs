using GraphicEditor.Repositories;
using GraphicEditor.Repositories.Interfaces;
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
        public void GetEquipmentByName_EquipmentExist_ReturnEquipments()
        {
            //Act
            var equipments = _eqipmentRepository.GetEquipmentsByName("Bed");

            //Assert
            Assert.NotNull(equipments);
            foreach (var equipment in equipments)
                Assert.Equal("Bed", equipment.Name);
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
