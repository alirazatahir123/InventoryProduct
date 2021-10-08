using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryProduct
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<InventoryProductIdentityServerModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
