using System;

namespace MicroDojoGateway.WebBff.ViewModels
{
    public class PersonPurchaseVM
    {
        public int Id { get; set; }
        public Guid PersonRefId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}