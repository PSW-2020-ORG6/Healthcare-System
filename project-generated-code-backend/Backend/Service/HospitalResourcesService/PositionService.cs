using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class PositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService()
        {
            _positionRepository = new PositionDatabaseSql();
        }

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public Position GetById(string id)
        {
            return _positionRepository.GetById(id);
        }

        public List<Position> GetAll()
        {
            return _positionRepository.GetAll();
        }

        public void EditPosition(Position position)
        {
            _positionRepository.Update(position);
        }

        public void NewPosition(Position position)
        {
            _positionRepository.Save(position);
        }

        public void DeletePosition(Position position)
        {
            _positionRepository.Delete(position.SerialNumber);
        }
    }
}