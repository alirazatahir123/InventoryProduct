using InventoryProduct.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace InventoryProduct.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(InventoryProductEntityFrameworkCoreModule),
        typeof(InventoryProductApplicationContractsModule)
        )]
    public class InventoryProductDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
