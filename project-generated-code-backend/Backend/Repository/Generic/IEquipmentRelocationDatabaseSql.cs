using HealthClinicBackend.Backend.Model.Schedule;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IEquipmentRelocationDatabaseSql : IGenericRepository<EquipmentRelocation>
    {
        EquipmentRelocation GetBySerialNumber(string serialNumber);
    }
}
