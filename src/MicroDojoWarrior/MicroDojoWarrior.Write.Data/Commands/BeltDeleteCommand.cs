using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Write.Data.Commands
{
    public class BeltDeleteCommand : ICommand
    {
        public int Id { get; set; }

        public BeltDeleteCommand(int id)
        {
            Id = id;
        }
    }
}