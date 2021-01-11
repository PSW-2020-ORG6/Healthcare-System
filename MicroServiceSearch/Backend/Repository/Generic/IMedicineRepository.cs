using MicroServiceSearch.Backend.Model;
using System.Collections.Generic;

namespace MicroServiceSearch.Backend.Repository.Generic
{
    public interface IMedicineRepository : IGenericMsSearchRepository<Medicine>
    {
        public new List<Medicine> GetAll();
        public List<Medicine> GetApproved();
        public List<Medicine> GetWaiting();
        List<Medicine> GetByName(string name);
    }
}