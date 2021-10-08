using InventoryProduct.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace InventoryProduct
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    public class InventoryProductDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            InventoryProductGlobalFeatureConfigurator.Configure();
            InventoryProductModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<InventoryProductDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<InventoryProductResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/InventoryProduct");

                options.DefaultResourceType = typeof(InventoryProductResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("InventoryProduct", typeof(InventoryProductResource));
            });
        }
    }
}
