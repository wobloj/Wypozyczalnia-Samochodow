using Microsoft.EntityFrameworkCore;
using WypozyczalniaSamochodow.Models.Cars;
using WypozyczalniaSamochodow.Models.Rentals;
using WypozyczalniaSamochodow.Models.Users;

namespace WypozyczalniaSamochodow.Context
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext() { }

        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }

        public DbSet<CarModel> Cars { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }
    }
}
