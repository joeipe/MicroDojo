using MicroDojoPurchase.Write.Domain.Enums;
using SharedKernel;
using System.Collections.Generic;

namespace MicroDojoPurchase.Write.Domain
{
    public class Stock : Entity
    {
        public string Item { get; set; }
        public Size Size { get; set; }

        public List<Order> Orders { get; set; }
    }
}