using InventoryProduct.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace InventoryProduct.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class InventoryProductController : AbpController
    {
        protected InventoryProductController()
        {
            LocalizationResource = typeof(InventoryProductResource);
        }
    }
}