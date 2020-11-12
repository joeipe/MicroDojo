using SharedKernel;
using System;

namespace MicroDojoWarrior.Write.Domain
{
    public class Person : Entity
    {
        public Guid PersonRefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int BeltId { get; set; }
        public int Stripes { get; set; }

        public Belt Belt { get; set; }
    }
}