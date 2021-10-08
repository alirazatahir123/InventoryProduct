using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace InventoryProduct
{
    [Dependency(ReplaceServices = true)]
    public class InventoryProductBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "InventoryProduct";
    }
}
