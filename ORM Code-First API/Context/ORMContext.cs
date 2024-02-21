using ORM_Code_First_API.Models;
using ORM_Code_First_API.Returns;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata;
namespace ORM_Code_First_API.Context
{
    public class ORMContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Models.Project> Projects { get; set; }

        //public DbSet<DepartmentReturn> departmentReturns { get; set; }
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
            // Configure
            modelBuilder.UseIdentityColumns();
            modelBuilder.Entity<ModelBase>()
                .UseTpcMappingStrategy();

            // Configure Primary Key with Identity(1,1)
            modelBuilder.Entity<ModelBase>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<ModelBase>()
                .Property(b => b.Id)
                .UseIdentityColumn(1,1);

            // Configure Manager ForeignKey
            modelBuilder.Entity<Manager>()
                .HasOne(p => p.Team)
                .WithOne(m => m.Manager)
                .HasForeignKey<Manager>(o => o.TeamId);
        }
    }
}
