using System.Threading.Tasks;

namespace InventoryProduct.Data
{
    public interface IInventoryProductDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
