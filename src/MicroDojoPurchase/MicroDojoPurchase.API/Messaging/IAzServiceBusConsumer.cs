using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroDojoPurchase.API.Messaging
{
    public interface IAzServiceBusConsumer
    {
        void Start();
        void Stop();
    }
}
