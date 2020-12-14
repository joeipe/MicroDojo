using MicroDojoWarrior.Read.Data.Queries;
using MicroDojoWarrior.Read.Domain;
using System.Collections.Generic;

namespace MicroDojoWarrior.Read.Data.Interfaces
{
    public interface IWarriorReadDataService
    {
        IEnumerable<Belt> GetBelt(GetBeltQuery query);

        Belt GetBeltById(GetBeltByIdQuery query);

        IEnumerable<Person> GetPerson(GetPersonQuery query);

        Person GetPersonById(GetPersonByIdQuery query);
    }
}