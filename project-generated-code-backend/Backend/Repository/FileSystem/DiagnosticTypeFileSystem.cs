using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
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
