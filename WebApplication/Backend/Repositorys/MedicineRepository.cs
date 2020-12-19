// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using HealthClinicBackend.Backend.Repository.DatabaseSql;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class MedicineRepository : IMedicineRepository
//     {
//         private MedicineDatabaseSql _medicineRepository;
//
//         public MedicineRepository()
//         {
//             _medicineRepository = new MedicineDatabaseSql();
//         }
//
//         public List<Medicine> GetMedicinesByName(string name)
//         {
//             return _medicineRepository.GetByName(name);
//         }
//
//         public List<Medicine> GetAllMedicines()
//         {
//             return _medicineRepository.GetAll();
//         }
//     }
// }