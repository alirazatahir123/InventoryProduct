using Volo.Abp.Settings;

namespace InventoryProduct.Settings
{
    public class InventoryProductSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(InventoryProductSettings.MySetting1));
        }
    }
}
