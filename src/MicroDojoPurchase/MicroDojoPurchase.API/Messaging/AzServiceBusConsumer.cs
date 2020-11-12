using MicroDojoPurchase.API.Messages;
using MicroDojoPurchase.Application.Interfaces;
using MicroDojoPurchase.ViewModels;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroDojoPurchase.API.Messaging
{
    public class AzServiceBusConsumer : IAzServiceBusConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly IPurchaseAppService _purchaseAppService;

        private readonly IQueueClient warriorPersonAddMessageReceiverClient;
        private readonly IQueueClient warriorPersonUpdateMessageReceiverClient;
        private readonly IQueueClient warriorPersonDeleteMessageReceiverClient;

        public AzServiceBusConsumer(IConfiguration configuration, IPurchaseAppService purchaseAppService)
        {
            _configuration = configuration;
            _purchaseAppService = purchaseAppService;

            var serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            warriorPersonAddMessageReceiverClient = new QueueClient(serviceBusConnectionString, "warriorpersonaddedmessagequeue");
            warriorPersonUpdateMessageReceiverClient = new QueueClient(serviceBusConnectionString, "warriorpersonupdatedmessagequeue");
            warriorPersonDeleteMessageReceiverClient = new QueueClient(serviceBusConnectionString, "warriorpersondeletedmessagequeue");
        }

        public void Start()
        {
            // Set the options for the message handler
            var options = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                AutoComplete = false,
                MaxConcurrentCalls = 10,
                MaxAutoRenewDuration = TimeSpan.FromSeconds(30)
            };

            // Create a message pump using OnMessage
            warriorPersonAddMessageReceiverClient.RegisterMessageHandler(OnWarriorPersonAddedAsync, options);
            warriorPersonUpdateMessageReceiverClient.RegisterMessageHandler(OnWarriorPersonUpdatedAsync, options);
            warriorPersonDeleteMessageReceiverClient.RegisterMessageHandler(OnWarriorPersonDeletedAsync, options);
        }

        public void Stop()
        {
            StopReceivingAsync().Wait();
        }

        private async Task OnWarriorPersonAddedAsync(Message message, CancellationToken token)
        {
            // Deserialize the message body.
            var messageBodyText = Encoding.UTF8.GetString(message.Body);

            var value = JsonConvert.DeserializeObject<WarriorPersonAddMessage>(messageBodyText);
            var vm = new PersonVM 
            { 
                PersonRefId = value.PersonRefId,
                Name = $"{value.FirstName} {value.LastName}",
                Address = value.Address,
            };
            _purchaseAppService.AddPerson(vm);

            // Complete the message
            await warriorPersonAddMessageReceiverClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private async Task OnWarriorPersonUpdatedAsync(Message message, CancellationToken token)
        {
            // Deserialize the message body.
            var messageBodyText = Encoding.UTF8.GetString(message.Body);

            var value = JsonConvert.DeserializeObject<WarriorPersonUpdateMessage>(messageBodyText);
            var vm = new PersonVM
            {
                PersonRefId = value.PersonRefId,
                Name = $"{value.FirstName} {value.LastName}",
                Address = value.Address,
            };
            _purchaseAppService.UpdatePerson(vm);

            // Complete the message
            await warriorPersonUpdateMessageReceiverClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private async Task OnWarriorPersonDeletedAsync(Message message, CancellationToken token)
        {
            // Deserialize the message body.
            var messageBodyText = Encoding.UTF8.GetString(message.Body);

            var value = JsonConvert.DeserializeObject<WarriorPersonDeleteMessage>(messageBodyText);
            _purchaseAppService.DeletePerson(value.PersonRefId);

            // Complete the message
            await warriorPersonDeleteMessageReceiverClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            //Console.WriteLine(exceptionReceivedEventArgs.Exception.Message, ConsoleColor.Red);

            return Task.CompletedTask;
        }

        private async Task StopReceivingAsync()
        {
            // Close the client, which will stop the message pump.
            await warriorPersonAddMessageReceiverClient.CloseAsync();
            await warriorPersonUpdateMessageReceiverClient.CloseAsync();
            await warriorPersonDeleteMessageReceiverClient.CloseAsync();
        }

    }
}
