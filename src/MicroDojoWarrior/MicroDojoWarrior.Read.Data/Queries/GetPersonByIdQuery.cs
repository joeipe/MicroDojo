using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroDojoWarrior.Read.Data.Queries
{
    public sealed class GetPersonByIdQuery : IQuery<Person>
    {
        public int Id { get; set; }

        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
