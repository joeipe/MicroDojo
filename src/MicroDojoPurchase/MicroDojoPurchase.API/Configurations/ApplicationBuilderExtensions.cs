using MicroDojoPurchase.API.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroDojoPurchase.API.Configurations
{
    public static class ApplicationBuilderExtensions
    {
        public static IAzServiceBusConsumer ServiceBusConsumer { get; set; }

        public static IApplicationBuilder UseAzServiceBusConsumer(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            ServiceBusConsumer = scope.ServiceProvider.GetService<IAzServiceBusConsumer>();
            var hostApplicationLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
            hostApplicationLifetime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            ServiceBusConsumer.Start();
        }

        private static void OnStopping()
        {
            ServiceBusConsumer.Stop();
        }
    }
}
