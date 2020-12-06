using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Xunit;

namespace HealthClinicBackendTests
{
    public class HospitalRepositoryTest
    {
        [Fact]
        public void TestGetAllBuildings_ReturnsNotNull()
        {
            // GIVEN
            var subject = new BuildingDatabaseSql();

            // WHEN
            var result = subject.GetAll();
            foreach (var building in result)
            {
                Assert.NotNull(building.Floors);
            }

            // THEN
            Assert.NotEmpty(result);
        }
        
        [Fact]
        public void TestGetAllFloors_ReturnsNotNull()
        {
            // GIVEN
            var subject = new FloorDatabaseSql();

            // WHEN
            var result = subject.GetAll();
            foreach (var floor in result)
            {
                Assert.NotNull(floor.Rooms);
            }

            // THEN
            Assert.NotEmpty(result);
        }
        
        [Fact]
        public void TestGetAllRooms_ReturnsNotNull()
        {
            // GIVEN
            var subject = new RoomDatabaseSql();

            // WHEN
            var result = subject.GetAll();
            foreach (var room in result)
            {
                Assert.NotNull(room.Floor);
                Assert.NotNull(room.RoomType);
                Assert.NotNull(room.Equipment);
                Assert.NotNull(room.Beds);
            }

            // THEN
            Assert.NotEmpty(result);
        }
        
        [Fact]
        public void TestGetAllEquipment_ReturnsNotNull()
        {
            // GIVEN
            var subject = new EquipmentDatabaseSql();

            // WHEN
            var result = subject.GetAll();
            foreach (var equipment in result)
            {
                Assert.NotNull(equipment.Building);
                Assert.NotNull(equipment.Floor);
                Assert.NotNull(equipment.Room);
            }

            // THEN
            Assert.NotEmpty(result);
        }
        
        [Fact]
        public void TestGetAllBeds_ReturnsNotNull()
        {
            // GIVEN
            var subject = new BedDatabaseSql();

            // WHEN
            var result = subject.GetAll();
            foreach (var room in result)
            {
                Assert.NotNull(room.Building);
                Assert.NotNull(room.Floor);
                Assert.NotNull(room.Room);
                Assert.NotNull(room.Patient);
            }

            // THEN
            Assert.NotEmpty(result);
        }
    }
}