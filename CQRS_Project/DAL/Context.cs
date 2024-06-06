using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6VB768D\\SQLEXPRESS02; initial catalog=DbCqrs; integrated Security=true;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
