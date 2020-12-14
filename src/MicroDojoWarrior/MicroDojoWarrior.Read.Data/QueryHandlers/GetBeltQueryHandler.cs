using Dapper.Contrib.Extensions;
using MicroDojoWarrior.Read.Data.Queries;
using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroDojoWarrior.Read.Data.QueryHandlers
{
    public sealed class GetBeltQueryHandler : IQueryHandler<GetBeltQuery, List<Belt>>
    {
        private readonly ReadDbContext _dataContext;

        public GetBeltQueryHandler(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Belt> Handle(GetBeltQuery query)
        {
            var data = _dataContext.db.GetAll<Belt>().ToList();
            return data;
        }
    }
}
