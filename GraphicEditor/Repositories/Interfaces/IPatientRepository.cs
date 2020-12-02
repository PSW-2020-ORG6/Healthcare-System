using Model.Accounts;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        Patient GetPatientBySerialNumber(string serialNumber);
    }
}
