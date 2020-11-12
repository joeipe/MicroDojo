namespace MicroDojoWarrior.Integration.MessagingBus.Interfaces
{
    public interface IBus
    {
        void Send(string message, string queueName);
    }
}