using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroDojoGateway.WebBff.ViewModels
{
    public class PersonVM
    {
        public int Id { get; set; }
        public Guid PersonRefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int BeltId { get; set; }
        public int Stripes { get; set; }
    }
}
