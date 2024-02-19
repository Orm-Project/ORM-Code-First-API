using ORM_Code_First_API.Models;
using Microsoft.EntityFrameworkCore;
namespace ORM_Code_First_API.Context
{
    public class ORMContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ORMDBConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //// Configure Manager Table
            //modelBuilder.Entity<Manager>().ToTable("Managers");

            //modelBuilder.Entity<Manager>()
            //    .HasKey(m => m.Id); // Set Primary key

            //modelBuilder.Entity<Manager>()
            //    .Property(m => m.ManagerDescription);

            modelBuilder.Entity<Manager>() // One to One | Manager To Department
                .HasOne<Department>(m => m.Department)
                .WithOne(n => n.Manager);
            //    .HasForeignKey<Department>(m => m.ManagerId);



            //// Configure Departments table
            //modelBuilder.Entity<Department>().ToTable("Departments");

            //modelBuilder.Entity<Department>()
            //    .HasKey(m => m.Id); // Set Primary key

            //modelBuilder.Entity<Department>()
            //    .Property(m => m.Name);



            //// Configure Projects table
            //modelBuilder.Entity<Project>().ToTable("Projects");

            //modelBuilder.Entity<Project>()
            //    .HasKey(m => m.Id); // Set Primary key

            //modelBuilder.Entity<Project>()
            //    .Property(p => p.Name);

            //modelBuilder.Entity<Project>() // Many to one
            //    .HasOne<Department>(p => p.Department)
            //    .WithMany(m => m.Projects)
            //    .HasForeignKey(o => o.DepartmentId);

            //// Configure Employee Table

            //modelBuilder.Entity<Employee>().ToTable("Employees");

            //modelBuilder.Entity<Employee>()
            //    .HasKey(m => m.Id); // Set Primary key

            //modelBuilder.Entity<Employee>()
            //    .Property(p => p.FirstName);

            //modelBuilder.Entity<Employee>()
            //    .Property(p => p.LastName);

            modelBuilder.Entity<Employee>() // Many to one | Employees to Department
                .HasOne<Department>(p => p.Department)
                .WithMany(m => m.Employees)
                .HasForeignKey(o => o.DepartmentId);
        }
        public DbSet<ORM_Code_First_API.Models.Department> Department { get; set; } = default!;
    }
}
