using MicroDojoWarrior.Write.Data.Commands;
using MicroDojoWarrior.Write.Data.Interfaces;
using SharedKernel.Services;

namespace MicroDojoWarrior.Write.Data.Services
{
    public class WarriorWriteDataService : IWarriorWriteDataService
    {
        private readonly Messages _messages;

        public WarriorWriteDataService(Messages messages)
        {
            _messages = messages;
        }

        #region Belt

        public void AddBelt(BeltAddCommand data)
        {
            _messages.Dispatch(data);
        }

        public void UpdateBelt(BeltUpdateCommand data)
        {
            _messages.Dispatch(data);
        }

        public void DeleteBelt(BeltDeleteCommand data)
        {
            _messages.Dispatch(data);
        }

        #endregion Belt

        #region Person

        public void AddPerson(PersonAddCommand data)
        {
            _messages.Dispatch(data);
        }

        public void UpdatePerson(PersonUpdateCommand data)
        {
            _messages.Dispatch(data);
        }

        public void DeletePerson(PersonDeleteCommand data)
        {
            _messages.Dispatch(data);
        }

        #endregion Person
    }
}