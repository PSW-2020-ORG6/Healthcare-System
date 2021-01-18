using MicroServiceFeedback.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceFeedback.Backend.Repository.DatabaseSql
{
    public class MsFeedbackDbContext : DbContext
    {
        public DbSet<Feedback> Feedback { get; set; }
        public MsFeedbackDbContext(DbContextOptions<MsFeedbackDbContext> options) : base(options)
        {
        }
    }
}