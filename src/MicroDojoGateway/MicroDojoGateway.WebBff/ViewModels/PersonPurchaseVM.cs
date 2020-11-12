using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
