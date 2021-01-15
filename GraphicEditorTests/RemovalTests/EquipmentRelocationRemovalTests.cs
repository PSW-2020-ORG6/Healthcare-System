using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.SchedulingService;
using Moq;
using System;
using Xunit;

namespace GraphicEditorTests.RemovalTests
{
    public class EquipmentRelocationSearchesTests
    {
        private readonly EquipmentRelocation equipmentRelocation;

        public EquipmentRelocationSearchesTests()
        {
            Equipment equipment = new Equipment("80", "Table", "18");
            equipmentRelocation = new EquipmentRelocation(DateTime.Now, DateTime.Now, equipment, "101", 3);
        }

        [Fact]
        public void RemoveEquipmentRelocation_EquipmentRelocationRemoved_VerifyAction()
        {
            var stubEquipmentRelocationRepository = new Mock<IEquipmentRelocationDatabaseSql>();
            stubEquipmentRelocationRepository.Setup(er => er.Delete(It.IsAny<string>()));

            EquipmentRelocationService service = new EquipmentRelocationService(stubEquipmentRelocationRepository.Object);
            service.DeleteEquipmentRelocation(equipmentRelocation);

            stubEquipmentRelocationRepository.Verify(er => er.Delete(equipmentRelocation.SerialNumber));
        }
    }
}
