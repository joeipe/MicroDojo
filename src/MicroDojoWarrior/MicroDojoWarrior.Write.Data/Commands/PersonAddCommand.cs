using SharedKernel.Interfaces;
using System;

namespace MicroDojoWarrior.Write.Data.Commands
{
    public class PersonAddCommand : ICommand
    {
        public Guid PersonRefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int BeltId { get; set; }
        public int Stripes { get; set; }

        public PersonAddCommand(string firstName, string lastName, DateTime dateOfBirth, string address, int beltId, int stripes)
        {
            PersonRefId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            BeltId = beltId;
            Stripes = stripes;
        }
    }
}