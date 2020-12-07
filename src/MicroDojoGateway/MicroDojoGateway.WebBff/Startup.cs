using MicroDojoGateway.WebBff.Services;
using MicroDojoGateway.WebBff.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace MicroDojoGateway.WebBff
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
            services.AddControllers();

            services.AddHttpClient<IWarriorService, WarriorService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44326/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            services.AddHttpClient<IPurchaseService, PurchaseService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44396/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Micro Dojo Gateway API", Version = "v1" });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Micro Dojo Gateway API V1");
            });
        }
    }
}