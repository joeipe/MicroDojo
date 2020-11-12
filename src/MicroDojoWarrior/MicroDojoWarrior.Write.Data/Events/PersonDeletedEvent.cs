using SharedKernel;
using SharedKernel.Interfaces;
using System;

namespace MicroDojoWarrior.Write.Data.Events
{
    public class PersonDeletedEvent : IDomainEvent
    {
        public Guid PersonRefId { get; set; }
        public PersonDeletedEvent(Guid personRefId)
        {
            PersonRefId = personRefId;
        }
    }
}