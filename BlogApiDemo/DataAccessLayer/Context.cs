using BlogApiDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CoreBlogApiDb;Trusted_Connection=true;");

            //optionsBuilder.UseSqlServer("Server=DESKTOP-ARPGO20; Database=CoreBlogDb; Trusted_Connection=True; TrustServerCertificate=True;");

        }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
