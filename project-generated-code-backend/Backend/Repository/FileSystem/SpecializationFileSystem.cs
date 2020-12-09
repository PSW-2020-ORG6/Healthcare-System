using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class SpecializationFileSystem : GenericFileSystem<Specialization>, ISpecializationRepository
    {
        public SpecializationFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/specializations.txt";
        }
        public override Specialization Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Specialization>(objectStringFormat);
        }

        public List<Specialization> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
