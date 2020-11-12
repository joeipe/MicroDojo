using SharedKernel;
using System.Collections.Generic;

namespace MicroDojoWarrior.Write.Domain
{
    public class Belt : Entity
    {
        public string Color { get; set; }

        public List<Person> People { get; set; }
    }
}