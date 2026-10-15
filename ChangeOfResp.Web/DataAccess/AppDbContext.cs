using ChangeOfResp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChangeOfResp.Web.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KORAYHAN\\SQLEXPRESS;database=ChainOfRespDb;integrated security=true; trustServerCertificate=true");
        }
        public DbSet<CustomerProcess> CustomerProcesss { get; set; }
    }
}
