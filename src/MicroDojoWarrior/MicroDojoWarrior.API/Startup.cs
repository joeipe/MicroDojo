using MicroDojoWarrior.API.Configurations;
using MicroDojoWarrior.Application.Interfaces;
using MicroDojoWarrior.Application.Services;
using MicroDojoWarrior.Integration.MessagingBus;
using MicroDojoWarrior.Integration.MessagingBus.Interfaces;
using MicroDojoWarrior.Read.Data;
using MicroDojoWarrior.Read.Data.Interfaces;
using MicroDojoWarrior.Read.Data.Services;
using MicroDojoWarrior.Write.Data;
using MicroDojoWarrior.Write.Data.EventDispatchers;
using MicroDojoWarrior.Write.Data.Interfaces;
using MicroDojoWarrior.Write.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SharedKernel.Services;

namespace MicroDojoWarrior.API
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

            services.AddDbContext<WriteDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DBConnectionString"))
                );
            services.AddScoped(x =>
                    new ReadDbContext(Configuration.GetConnectionString("DBConnectionString"))
                );
            services.AddScoped<Uow>();
            services.AddScoped<IWarriorWriteDataService, WarriorWriteDataService>();
            services.AddScoped<IWarriorReadDataService, WarriorReadDataService>();
            services.AddScoped<IWarriorAppService, WarriorAppService>();

            services.AddScoped<Messages>();
            services.AddHandler();

            services.AddScoped<IBus>(c => new AzServiceBus(Configuration["ServiceBusConnectionString"]));
            services.AddScoped<MessageBus>();
            services.AddScoped<EventDispatcher>();

            services.AddAutoMapperSetup();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warrior API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WriteDbContext dbContext)
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warrior API V1");
            });
        }
    }
}