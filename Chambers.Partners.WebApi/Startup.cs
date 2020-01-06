using Chambers.Partners.Domain.Factories;
using Chambers.Partners.Domain.Providers;
using Chambers.Partners.Domain.Services;
using Chambers.Partners.WebApi.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chambers.Partners.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<ICardGameProvider, InMemoryCardGameProvider>();
            services.AddSingleton<IDealerProvider, InMemoryDealerProvider>();
            services.AddSingleton<IPlayerProvider, InMemoryPlayerProvider>();

            services.AddScoped<ICardGameMapper, CardGameMapper>();
            services.AddScoped<IGameFactory, GameFactory>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IGameService, GameService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
