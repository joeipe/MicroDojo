using MicroDojoWarrior.Integration.MessagingBus.Interfaces;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MicroDojoWarrior.Integration.MessagingBus
{
    public class AzServiceBus : IBus
    {
        private readonly string _connectionString;

        public AzServiceBus(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Send(string message, string queueName)
        {
            Console.WriteLine(message);
            SendTextString(message, queueName).Wait();
        }

        private async Task SendTextString(string text, string queueName)
        {
            // Create a client
            var client = new QueueClient(_connectionString, queueName);

            var message = new Message(Encoding.UTF8.GetBytes(text));
            await client.SendAsync(message);

            // Always close the client
            await client.CloseAsync();
        }
    }
}