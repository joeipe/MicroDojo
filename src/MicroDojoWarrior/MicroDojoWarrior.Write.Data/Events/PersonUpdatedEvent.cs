using SharedKernel.Interfaces;
using System;

namespace MicroDojoWarrior.Write.Data.Events
{
    public class PersonUpdatedEvent : IDomainEvent
    {
        public Guid PersonRefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int BeltId { get; set; }
        public int Stripes { get; set; }

        public PersonUpdatedEvent(Guid personRefId, string firstName, string lastName, DateTime dateOfBirth, string address, int beltId, int stripes)
        {
            PersonRefId = personRefId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            BeltId = beltId;
            Stripes = stripes;
        }
    }
}