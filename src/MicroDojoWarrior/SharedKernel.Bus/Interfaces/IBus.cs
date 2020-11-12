using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Bus.Interfaces
{
    public interface IBus
    {
        void Send(string message);
    }
}
