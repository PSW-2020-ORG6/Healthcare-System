using Model.Schedule;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IProcedureTypeRepository
    {
        ProcedureType GetProcedureTypeBySerialNumber(string serialNumber);
    }
}
