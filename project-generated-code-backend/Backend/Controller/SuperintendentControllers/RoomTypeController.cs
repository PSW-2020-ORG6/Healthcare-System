using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class RoomTypeController
    {
        public RoomTypeService roomTypeService;

        public RoomTypeController()
        {
            roomTypeService = new RoomTypeService();
        }

        public RoomType GetById(string id)
        {
            return roomTypeService.GetById(id);
        }

        public List<RoomType> GetByName(string name)
        {
            return roomTypeService.GetByName(name);
        }

        public List<RoomType> GetAll()
        {
            return roomTypeService.GetAll();
        }

        public void EditRoomType(RoomType roomType)
        {
            roomTypeService.EditRoomType(roomType);
        }

        public void NewRoomType(RoomType roomType)
        {
            roomTypeService.NewRoomType(roomType);
        }

        public void DeleteRoomType(RoomType roomType)
        {
            roomTypeService.DeleteRoomType(roomType);
        }
    }
}
