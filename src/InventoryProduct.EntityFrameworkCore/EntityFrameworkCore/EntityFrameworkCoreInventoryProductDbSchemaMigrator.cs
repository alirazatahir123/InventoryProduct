using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InventoryProduct.Data;
using Volo.Abp.DependencyInjection;

namespace InventoryProduct.EntityFrameworkCore
{
    public class EntityFrameworkCoreInventoryProductDbSchemaMigrator
        : IInventoryProductDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreInventoryProductDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the InventoryProductDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<InventoryProductDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
