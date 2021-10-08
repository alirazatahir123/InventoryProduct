using InventoryProduct.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace InventoryProduct
{
    [DependsOn(
        typeof(InventoryProductEntityFrameworkCoreTestModule)
        )]
    public class InventoryProductDomainTestModule : AbpModule
    {

    }
}