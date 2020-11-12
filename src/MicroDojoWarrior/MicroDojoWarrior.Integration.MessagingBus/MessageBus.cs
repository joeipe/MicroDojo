using MicroDojoWarrior.Integration.MessagingBus.Interfaces;
using SharedKernel.Extensions;
using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Integration.MessagingBus
{
    public class MessageBus
    {
        private readonly IBus _bus;

        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public void SendMessage(IDomainEvent ev, string queueName)
        {
            _bus.Send(ev.OutputJson(), queueName);
        }
    }
}