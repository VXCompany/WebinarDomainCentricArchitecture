using System.Linq;
using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web
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
            var options = new DbContextOptionsBuilder<WinkelDbContext>()
                           .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Winkel;Integrated Security=True")
                           .Options;

            var winkelDbContext = new WinkelDbContext(options);

            winkelDbContext.Database.EnsureCreated();

            VulTabellen(winkelDbContext);

            services.AddScoped(_ => winkelDbContext);

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

            if (!winkelDbContext.Produkten.Any())
            {
                winkelDbContext.Produkten.Add(new Produkt
                {
                    ProduktIdentificatie = "Appel",
                    Prijs = 0.56m
                });

                winkelDbContext.Produkten.Add(new Produkt
                {
                    ProduktIdentificatie = "Peer",
                    Prijs = 0.32m
                });
            }

            winkelDbContext.SaveChanges();
        }
    }
}
