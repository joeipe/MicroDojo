using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;
using System.Collections.Generic;

namespace MicroDojoWarrior.Read.Data.Queries
{
    public sealed class GetPersonQuery : IQuery<List<Person>>
    {
    }
}