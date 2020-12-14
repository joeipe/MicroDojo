using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;

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