using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class PositionController
    {
        public PositionService positionService;

        public PositionController()
        {
            positionService = new PositionService();
        }

        public Position GetById(string id)
        {
            return positionService.GetById(id);
        }

        public List<Position> GetAll()
        {
            return positionService.GetAll();
        }

        public void EditPosition(Position position)
        {
            positionService.EditPosition(position);
        }

        public void NewPosition(Position position)
        {
            positionService.NewPosition(position);
        }

        public void DeletePosition(Position position)
        {
            positionService.DeletePosition(position);
        }
    }
}
