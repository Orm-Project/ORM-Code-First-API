using ORM_Code_First_API.Models;
using Microsoft.EntityFrameworkCore;
namespace ORM_Code_First_API.Models
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
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookDBConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Manager Table
            modelBuilder.Entity<Manager>().ToTable("Managers");

            modelBuilder.Entity<Manager>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Manager>()
                .Property(m => m.ManagerDescription);

            // One To One | Manager To Department
            modelBuilder.Entity<Manager>()
                .HasOne<Department>(m => m.Department)
                .WithOne(n => n.Manager)
                .HasForeignKey<Department>(m => m.ManagerId);

            // Configure Departments table
            modelBuilder.Entity<Department>().ToTable("Departments");

            modelBuilder.Entity<Department>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Department>()
                .Property(m => m.Name);

            // One to many | One Department to Many Projects
            modelBuilder.Entity<Department>()
                .HasMany(m => m.Projects)
                .WithOne(n => n.Department)
                .HasForeignKey(p => p.DepartmentId);

            // Configure Projects table
            modelBuilder.Entity<Project>().ToTable("Projects");

            modelBuilder.Entity<Project>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Project>()
                .Property(p => p.Name);

            // Configure Employee Table

            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Employee>()
                .Property(p => p.FirstName);

            modelBuilder.Entity<Employee>()
                .Property(p => p.LastName);

            modelBuilder.Entity<Employee>()
                .HasOne<Department>(p => p.Department)
                .WithMany(m => m.Employees)
                .HasForeignKey(o => o.DepartmentId);

            ////Configure the Book table
            //modelBuilder.Entity<Book>().ToTable("Books");

            //modelBuilder.Entity<Book>()
            //    .HasKey(b => b.Id);

            //modelBuilder.Entity<Book>()
            //    .Property(b => b.Title)
            //    .HasMaxLength(100)
            //    .IsRequired();

            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.Publisher)
            //    .WithMany(p => p.Books)
            //    .HasForeignKey(b => b.PublisherId)
            //    .IsRequired();

            //modelBuilder.Entity<Book>()
            //    .HasMany(b => b.Authors)
            //    .WithMany(a => a.Books)
            //    .UsingEntity(j => j.ToTable("BookAuthor"));
        }
    }
}
