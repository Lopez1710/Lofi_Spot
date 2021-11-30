using Lofi_Spot.Data;
using Lofi_Spot.Repository;
using Lofi_Spot.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot
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
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient <ICarritos, CarritosRepository> ();
            services.AddTransient <ICategorias, CategoriasRepository> ();
            services.AddTransient <IDetallesDeCompras, DetalleDeComprasRepository> ();
            services.AddTransient <IDirecciones, DireccionesRepository> ();
            services.AddTransient <IProductos, ProductosRepository> ();
            services.AddTransient <IRoles, RolesRepository> ();
            services.AddTransient <ITarjetas, TarjetasRepository> ();
            services.AddTransient <IUsuarios, UsuariosRepository> ();
            services.AddTransient <INumeroCarrito, NumeroCarritoRepository>();
            services.AddTransient <IFactura, FacturaRepository>();
            services.AddTransient <IDetalleFactura, DetalleFactura>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Usuario}/{action=Direccion}/{id?}");
            });
        }
    }
}
