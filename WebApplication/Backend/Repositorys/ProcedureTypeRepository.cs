using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class ProcedureTypeRepository : IProcedureTypeRepository
    {
        private readonly ProcedureTypeDatabaseSql _procedureTypeRepository;

        public ProcedureTypeRepository()
        {
            _procedureTypeRepository = new ProcedureTypeDatabaseSql();
        }

        public ProcedureType GetProcedureTypeBySerialNumber(string serialNumber)
        {
            return _procedureTypeRepository.GetById(serialNumber);
        }
    }
}