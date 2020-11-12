using System;

namespace MicroDojoPurchase.ViewModels
{
    public class PersonVM
    {
        public int Id { get; set; }
        public Guid PersonRefId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}