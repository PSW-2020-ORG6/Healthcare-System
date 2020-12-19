// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using HealthClinicBackend.Backend.Repository.DatabaseSql;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class FloorRepository : IFloorRepository
//     {
//         private FloorDatabaseSql _floorRepository;
//
//         public FloorRepository()
//         {
//             _floorRepository = new FloorDatabaseSql();
//         }
//
//         public List<Floor> GetAllFloors()
//         {
//             return _floorRepository.GetAll();
//         }
//
//         public List<Floor> GetFloorsByName(string name)
//         {
//             return _floorRepository.GetByName(name);
//         }
//
//         public List<Floor> GetFloorsByBuildingSerialNumber(string buildingSerialNumber)
//         {
//             return _floorRepository.GetByBuildingSerialNumber(buildingSerialNumber);
//         }
//
//         public Floor GetFloorBySerialNumber(string serialNumber)
//         {
//             return _floorRepository.GetById(serialNumber);
//         }
//     }
// }