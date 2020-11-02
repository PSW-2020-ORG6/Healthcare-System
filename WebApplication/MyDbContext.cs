using Microsoft.EntityFrameworkCore;
using Model.Blog;

namespace WebApplication.Backend.Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Account account=new Account()
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = "1", Name = "Ime1", Text = "tekst komentara1",Approved=true },
                new Feedback { Id = "2", Name = "Ime2", Text = "tekst komentara2", Approved = false },
                new Feedback { Id = "3", Name = "Ime3", Text = "tekst komentara3", Approved = true } ,         
                new Feedback { Id = "4", Name = "Ime4", Text = "tekst komentara4", Approved = false },
                new Feedback { Id = "5", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "6", Name = "Ime6", Text = "tekst komentara6", Approved = true } ,
                new Feedback { Id = "7", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "8", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "9", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "10", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "11", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "15", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "17", Name = "Ime5", Text = "tekst komentara5", Approved = false },
                new Feedback { Id = "174", Name = "Ime5", Text = "tekst komentara5", Approved = false }








            );
        }
    }
}
