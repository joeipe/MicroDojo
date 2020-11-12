using System;

namespace MicroDojoPurchase.Read.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public Guid PersonRefId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}