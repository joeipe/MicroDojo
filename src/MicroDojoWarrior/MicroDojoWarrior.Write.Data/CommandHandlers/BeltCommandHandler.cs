using MicroDojoWarrior.Write.Data.Commands;
using MicroDojoWarrior.Write.Domain;
using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Write.Data.CommandHandlers
{
    public class BeltCommandHandler :
        ICommandHandler<BeltAddCommand>,
        ICommandHandler<BeltUpdateCommand>,
        ICommandHandler<BeltDeleteCommand>
    {
        private readonly Uow _uow;

        public BeltCommandHandler(Uow uow)
        {
            _uow = uow;
        }

        public void Handle(BeltAddCommand command)
        {
            var data = new Belt()
            {
                Color = command.Color
            };
            _uow.BeltsRepo.Create(data);
            _uow.Save();
        }

        public void Handle(BeltUpdateCommand command)
        {
            var data = _uow.BeltsRepo.Find(command.Id);
            if (data != null)
            {
                data.Color = command.Color;

                _uow.BeltsRepo.Update(data);
                _uow.Save();
            }
        }

        public void Handle(BeltDeleteCommand command)
        {
            var data = _uow.BeltsRepo.Find(command.Id);
            if (data != null)
            {
                _uow.BeltsRepo.Delete(data);
                _uow.Save();
            }
        }
    }
}