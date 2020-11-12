using SharedKernel.Bus.Interfaces;
using System;

namespace SharedKernel.Bus
{
    public sealed class Bus : IBus
    {
        public void Send(string message)
        {
            Console.WriteLine($"Message sent: '{message}'");
        }
    }
}
