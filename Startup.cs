using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using WebAPI.Data;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebAPIContext>(options =>
            {
                options.UseInMemoryDatabase("WebAPIInMemory"); // Nome do banco de dados InMemory
            });

            // Outros serviços
        }
    }
}
