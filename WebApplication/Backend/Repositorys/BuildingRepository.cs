// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using HealthClinicBackend.Backend.Repository.DatabaseSql;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class BuildingRepository : IBuildingRepository
//     {
//         private readonly BuildingDatabaseSql _buildingRepository;
//
//         public BuildingRepository()
//         {
//             _buildingRepository = new BuildingDatabaseSql();
//         }
//
//         public List<Building> GetAllBuildings()
//         {
//             return _buildingRepository.GetAll();
//         }
//
//         public List<Building> GetBuildingsByName(string name)
//         {
//             return _buildingRepository.GetByName(name);
//         }
//
//         public Building GetBuildingBySerialNumber(string serialNumber)
//         {
//             return _buildingRepository.GetById(serialNumber);
//         }
//     }
// }