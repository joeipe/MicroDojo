using MicroDojoWarrior.Write.Data.Commands;

namespace MicroDojoWarrior.Write.Data.Interfaces
{
    public interface IWarriorWriteDataService
    {
        void AddBelt(BeltAddCommand data);

        void UpdateBelt(BeltUpdateCommand data);

        void DeleteBelt(BeltDeleteCommand data);

        void AddPerson(PersonAddCommand data);

        void UpdatePerson(PersonUpdateCommand data);

        void DeletePerson(PersonDeleteCommand data);
    }
}