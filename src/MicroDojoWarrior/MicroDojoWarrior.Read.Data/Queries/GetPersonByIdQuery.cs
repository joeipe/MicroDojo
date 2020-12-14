using MicroDojoWarrior.Read.Domain;
using SharedKernel.Interfaces;

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