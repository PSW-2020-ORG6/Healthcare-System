using Model.MedicalExam;
using System.Collections.Generic;

namespace HealthClinic.Message
{
    internal class AddedDocumentsChangedMessage
    {
        public List<AdditionalDocument> documents { get; internal set; }
    }
}