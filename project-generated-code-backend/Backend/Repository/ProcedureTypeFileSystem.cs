using Backend.Repository;
using Model.Schedule;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
{
    public class ProcedureTypeFileSystem : GenericFileSystem<ProcedureType>, ProcedureTypeRepository
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
