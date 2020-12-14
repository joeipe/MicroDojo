using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroDojoWarrior.Read.Data.Queries
{
    public sealed class GetBeltByIdQuery : IQuery<Belt>
    {
        public int Id { get; set; }

        public GetBeltByIdQuery(int id)
        {
            Id = id;
        }
    }
}
