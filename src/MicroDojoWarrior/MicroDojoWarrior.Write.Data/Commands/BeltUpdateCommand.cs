using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Write.Data.Commands
{
    public class BeltUpdateCommand : ICommand
    {
        public int Id { get; set; }
        public string Color { get; set; }

        public BeltUpdateCommand(int id, string color)
        {
            Id = id;
            Color = color;
        }
    }
}