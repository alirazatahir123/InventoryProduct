using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace InventoryProduct.Data
{
    /* This is used if database provider does't define
     * IInventoryProductDbSchemaMigrator implementation.
     */
    public class NullInventoryProductDbSchemaMigrator : IInventoryProductDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}