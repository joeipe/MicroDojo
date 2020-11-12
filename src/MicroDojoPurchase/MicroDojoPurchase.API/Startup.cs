using MicroDojoPurchase.API.Configurations;
using MicroDojoPurchase.API.Messaging;
using MicroDojoPurchase.Application.Interfaces;
using MicroDojoPurchase.Application.Services;
using MicroDojoPurchase.Read.Data;
using MicroDojoPurchase.Read.Data.Interfaces;
using MicroDojoPurchase.Read.Data.Services;
using MicroDojoPurchase.Write.Data;
using MicroDojoPurchase.Write.Data.Interfaces;
using MicroDojoPurchase.Write.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MicroDojoPurchase.API
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

            services.AddDbContext<MicroDojoPurchaseWriteContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DBConnectionString"))
                );
            services.AddScoped(x =>
                    new ReadDbContext(Configuration.GetConnectionString("DBConnectionString"))
                );
            services.AddScoped<Uow>();
            services.AddScoped<IPurchaseWriteDataService, PurchaseWriteDataService>();
            services.AddScoped<IPurchaseReadDataService, PurchaseReadDataService>();
            services.AddScoped<IPurchaseAppService, PurchaseAppService>();

            services.AddScoped<IAzServiceBusConsumer, AzServiceBusConsumer>();

            services.AddAutoMapperSetup();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Purchase API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MicroDojoPurchaseWriteContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                dbContext.Database.Migrate();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Purchase API V1");
            });

            app.UseAzServiceBusConsumer();
        }
    }
}