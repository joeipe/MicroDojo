using Dapper;
using MicroDojoWarrior.Read.Data.Queries;
using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroDojoWarrior.Read.Data.QueryHandlers
{
    public sealed class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, List<Person>>
    {
        private readonly ReadDbContext _dataContext;

        public GetPersonQueryHandler(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Person> Handle(GetPersonQuery query)
        {
            var data = _dataContext.db.Query<Person>("select * from People").ToList();
            return data;
        }
    }
}
