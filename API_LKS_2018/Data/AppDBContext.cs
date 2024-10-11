using Microsoft.EntityFrameworkCore;
using API_LKS_2018.Models;

namespace API_LKS_2018.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }

        // untuk set data di database/models
        public DbSet<Employe> MsEmploye { get; set; }
        public DbSet<Menu> MsMenu { get; set; }
        public DbSet<RateUser> RateUsers { get; set; }
        public DbSet<Package> Packages { get; set; }

    }
}
