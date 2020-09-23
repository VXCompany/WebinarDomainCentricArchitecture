using System.Linq;
using ApplicationServices.UseCases;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.EFSqlStore;
using Infrastructure.EFSqlStore.Model;
using Infrastructure.EFSqlStore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DomainCentric.Web
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
            // Data store registraties
            services.AddScoped(wdbctx =>
            {
                var options = new DbContextOptionsBuilder<WinkelDbContext>()
                           .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Winkel;Integrated Security=True")
                           .Options;

                var winkelDbContext = new WinkelDbContext(options);

                winkelDbContext.Database.EnsureCreated();

                VulTabellen(winkelDbContext);

                return winkelDbContext;
            });

            services.AddScoped<IKlantRepository, KlantRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Application service registraties
            services.AddScoped<IOrderMetKortingUsecase, OrderMetKortingUsecase>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void VulTabellen(WinkelDbContext winkelDbContext)
        {
            if (!winkelDbContext.Klanten.Any())
            {
                winkelDbContext.Klanten.Add(new Klant
                {
                    KlantIdentificatie = "KL123"
                });
            }

            if (!winkelDbContext.Producten.Any())
            {
                winkelDbContext.Producten.Add(new Product
                {
                    ProductIdentificatie = "Appel",
                    Prijs = 0.56m
                });

                winkelDbContext.Producten.Add(new Product
                {
                    ProductIdentificatie = "Peer",
                    Prijs = 0.32m
                });
            }

            winkelDbContext.SaveChanges();
        }
    }
}
