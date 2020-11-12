using MicroDojoWarrior.Integration.MessagingBus;
using MicroDojoWarrior.Write.Data.Events;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroDojoWarrior.Write.Data.EventDispatchers
{
    public class EventDispatcher
    {
        private readonly MessageBus _messageBus;

        public EventDispatcher(MessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Dispatch(IEnumerable<IDomainEvent> events)
        {
            foreach (IDomainEvent ev in events)
            {
                Dispatch(ev);
            }
        }

        public void Dispatch(IDomainEvent ev)
        {
            switch (ev)
            {
                case PersonAddedEvent personAddedEvent:
                    _messageBus.SendMessage(personAddedEvent, "warriorpersonaddedmessagequeue");
                    break;

                case PersonUpdatedEvent personUpdatedEvent:
                    _messageBus.SendMessage(personUpdatedEvent, "warriorpersonupdatedmessagequeue");
                    break;

                case PersonDeletedEvent personDeletedEvent:
                    _messageBus.SendMessage(personDeletedEvent, "warriorpersondeletedmessagequeue");
                    break;

                default:
                    throw new Exception($"Unknown event type: '{ev.GetType()}'");
            }
        }
    }
}
