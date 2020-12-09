using Backend.Repository;
using HealthClinicBackend.Backend.Model.Accounts;
using Model.Accounts;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
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
    }
}
