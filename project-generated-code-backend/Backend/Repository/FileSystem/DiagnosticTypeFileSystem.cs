using HealthClinicBackend.Backend.Model.MedicalExam;
using Newtonsoft.Json;

namespace Backend.Repository
{
    public class DiagnosticTypeFileSystem : GenericFileSystem<DiagnosticType>, IDiagnosticTypeRepository
    {
        public DiagnosticTypeFileSystem()
        {
            path = @"./../../data/diagnostic_types.txt";
        }

        public override DiagnosticType Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<DiagnosticType>(objectStringFormat);
        }
    }
}
