using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IEquipmentRelocationDatabaseSql: IGenericRepository<EquipmentRelocation>
    {
        EquipmentRelocation GetBySerialNumber(string serialNumber);
    }
}
