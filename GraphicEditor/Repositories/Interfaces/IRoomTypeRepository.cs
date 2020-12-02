using Model.Hospital;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetAllGetRoomTypes();
        RoomType GetRoomTypeBySerialNumber(string serialNumber);

    }
}
