using Model.Hospital;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IRoomTypeRepository
    {
        RoomType GetRoomTypeBySerialNumber(string serialNumber);

    }
}
