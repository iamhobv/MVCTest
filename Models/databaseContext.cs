using lab2.Models.AuthModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab2.Models
{
    public class databaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<CrsByStd> CrsByStds { get; set; }

        public databaseContext(DbContextOptions<databaseContext> dbContextOptions)
        {

        }
        public databaseContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CrsDBLab2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}

