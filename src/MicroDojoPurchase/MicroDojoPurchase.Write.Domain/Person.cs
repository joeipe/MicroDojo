using SharedKernel;
using System;
using System.Collections.Generic;

namespace MicroDojoPurchase.Write.Domain
{
    public class Person : Entity
    {
        public Guid PersonRefId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}