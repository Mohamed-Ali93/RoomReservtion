using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RoomReservtion.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class RoomReservtionDbContextFactory : IDesignTimeDbContextFactory<RoomReservtionDbContext>
    {
        public RoomReservtionDbContext CreateDbContext(string[] args)
        {
            RoomReservtionEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<RoomReservtionDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new RoomReservtionDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RoomReservtion.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
