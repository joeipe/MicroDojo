using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Write.Data.Commands
{
    public class PersonDeleteCommand : ICommand
    {
        public int Id { get; set; }

        public PersonDeleteCommand(int id)
        {
            Id = id;
        }
    }
}