using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Write.Data.Commands
{
    public class BeltAddCommand : ICommand
    {
        public string Color { get; set; }

        public BeltAddCommand(string color)
        {
            Color = color;
        }
    }
}