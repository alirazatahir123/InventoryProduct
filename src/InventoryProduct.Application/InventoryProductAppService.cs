using System;
using System.Collections.Generic;
using System.Text;
using InventoryProduct.Localization;
using Volo.Abp.Application.Services;

namespace InventoryProduct
{
    /* Inherit your application services from this class.
     */
    public abstract class InventoryProductAppService : ApplicationService
    {
        protected InventoryProductAppService()
        {
            LocalizationResource = typeof(InventoryProductResource);
        }
    }
}
