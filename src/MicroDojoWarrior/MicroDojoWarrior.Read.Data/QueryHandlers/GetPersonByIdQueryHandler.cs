using Dapper;
using MicroDojoWarrior.Read.Data.Queries;
using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroDojoWarrior.Read.Data.QueryHandlers
{
    public sealed class GetPersonByIdQueryHandler : IQueryHandler<GetPersonByIdQuery, Person>
    {
        private readonly ReadDbContext _dataContext;

        public GetPersonByIdQueryHandler(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Person Handle(GetPersonByIdQuery query)
        {
            var data = _dataContext.db.QuerySingle<Person>("select * from People where Id = @Id", new { query.Id });
            return data;
        }
    }
}
