using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class ProcedureTypeFileSystem : GenericFileSystem<ProcedureType>, IProcedureTypeRepository
    {
        public ProcedureTypeFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/procedure_types.txt";
            path = @"./../../data/procedure_types.txt";
        }
        public override ProcedureType Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<ProcedureType>(objectStringFormat);
        }
    }
}
