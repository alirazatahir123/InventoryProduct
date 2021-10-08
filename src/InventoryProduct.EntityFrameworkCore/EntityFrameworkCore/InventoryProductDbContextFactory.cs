using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InventoryProduct.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class InventoryProductDbContextFactory : IDesignTimeDbContextFactory<InventoryProductDbContext>
    {
        public InventoryProductDbContext CreateDbContext(string[] args)
        {
            InventoryProductEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<InventoryProductDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new InventoryProductDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../InventoryProduct.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
