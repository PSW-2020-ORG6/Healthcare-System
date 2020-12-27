using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        public DbContextOptions<IAHealthCareSystemDbContext> options = new DbContextOptionsBuilder<IAHealthCareSystemDbContext>()
               .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root").UseLazyLoadingProxies()
               .Options;
        public readonly IAHealthCareSystemDbContext dbContext;

        public TenderRepository()
        {
            this.dbContext = new IAHealthCareSystemDbContext(options);
        }

        public bool AddTender(Tender tender)
        {
                dbContext.Add<Tender>(tender);
                dbContext.SaveChanges();
                return true;
            
        }

        public List<Tender> GetAllTenders()
        {
            return dbContext.Tender.ToList();
        }
    }
}
