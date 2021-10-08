using Volo.Abp.Modularity;

namespace InventoryProduct
{
    [DependsOn(
        typeof(InventoryProductApplicationModule),
        typeof(InventoryProductDomainTestModule)
        )]
    public class InventoryProductApplicationTestModule : AbpModule
    {

    }
}