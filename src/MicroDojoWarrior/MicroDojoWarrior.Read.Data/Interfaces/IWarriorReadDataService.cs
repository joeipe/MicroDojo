using MicroDojoWarrior.Read.Domain;
using System.Collections.Generic;

namespace MicroDojoWarrior.Read.Data.Interfaces
{
    public interface IWarriorReadDataService
    {
        IEnumerable<Belt> GetBelt();

        Belt GetBeltById(int id);

        IEnumerable<Person> GetPerson();

        Person GetPersonById(int id);
    }
}