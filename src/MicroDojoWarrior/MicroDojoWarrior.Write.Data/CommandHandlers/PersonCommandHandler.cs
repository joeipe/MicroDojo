using MicroDojoWarrior.Write.Data.Commands;
using MicroDojoWarrior.Write.Data.Events;
using MicroDojoWarrior.Write.Domain;
using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Write.Data.CommandHandlers
{
    public class PersonCommandHandler :
        ICommandHandler<PersonAddCommand>,
        ICommandHandler<PersonUpdateCommand>,
        ICommandHandler<PersonDeleteCommand>
    {
        private readonly Uow _uow;

        public PersonCommandHandler(Uow uow)
        {
            _uow = uow;
        }

        public void Handle(PersonAddCommand command)
        {
            var data = new Person()
            {
                PersonRefId = command.PersonRefId,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                Address = command.Address,
                BeltId = command.BeltId,
                Stripes = command.Stripes
            };
            _uow.PeopleRepo.Create(data);
            data.RaiseDomainEvent(new PersonAddedEvent(data.PersonRefId, command.FirstName, command.LastName, command.DateOfBirth, command.Address, command.BeltId, command.Stripes));
            _uow.Save();
        }

        public void Handle(PersonUpdateCommand command)
        {
            var data = _uow.PeopleRepo.Find(command.Id);
            if (data != null)
            {
                data.FirstName = command.FirstName;
                data.LastName = command.LastName;
                data.DateOfBirth = command.DateOfBirth;
                data.Address = command.Address;
                data.BeltId = command.BeltId;
                data.Stripes = command.Stripes;

                _uow.PeopleRepo.Update(data);
                data.RaiseDomainEvent(new PersonUpdatedEvent(data.PersonRefId, command.FirstName, command.LastName, command.DateOfBirth, command.Address, command.BeltId, command.Stripes));
                _uow.Save();
            }
        }

        public void Handle(PersonDeleteCommand command)
        {
            var data = _uow.PeopleRepo.Find(command.Id);
            if (data != null)
            {
                _uow.PeopleRepo.Delete(data);
                data.RaiseDomainEvent(new PersonDeletedEvent(data.PersonRefId));
                _uow.Save();
            }
        }
    }
}