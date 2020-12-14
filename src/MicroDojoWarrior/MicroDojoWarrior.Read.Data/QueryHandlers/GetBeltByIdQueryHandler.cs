using Dapper.Contrib.Extensions;
using MicroDojoWarrior.Read.Data.Queries;
using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;

namespace MicroDojoWarrior.Read.Data.QueryHandlers
{
    public sealed class GetBeltByIdQueryHandler : IQueryHandler<GetBeltByIdQuery, Belt>
    {
        private readonly ReadDbContext _dataContext;

        public GetBeltByIdQueryHandler(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Belt Handle(GetBeltByIdQuery query)
        {
            var data = _dataContext.db.Get<Belt>(query.Id);
            return data;
        }
    }
}