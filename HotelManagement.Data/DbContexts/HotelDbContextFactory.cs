using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using HotelManagement.Data.DbContexts;


public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();
        optionsBuilder.UseSqlServer("Server=SQLEXPRESS;Database=HotelDb;Trusted_Connection=True;TrustServerCertificate=True;");



        return new HotelDbContext(optionsBuilder.Options);
    }
}
