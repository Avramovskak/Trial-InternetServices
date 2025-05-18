using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelManagement.Infrastructure.Persistence;

public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();
        optionsBuilder.UseSqlServer("Server=RASTKO;Database=HotelDb;Trusted_Connection=True;TrustServerCertificate=True;");



        return new HotelDbContext(optionsBuilder.Options);
    }
}
