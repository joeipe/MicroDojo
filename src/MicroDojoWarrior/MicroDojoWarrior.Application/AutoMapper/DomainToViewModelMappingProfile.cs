using AutoMapper;
using MicroDojoWarrior.Read.Data.Queries;
using MicroDojoWarrior.Read.Domain;
using MicroDojoWarrior.ViewModels;

namespace MicroDojoWarrior.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<int, GetBeltByIdQuery>()
                .ConvertUsing(c => new GetBeltByIdQuery(c));
            CreateMap<int, GetPersonByIdQuery>()
                .ConvertUsing(c => new GetPersonByIdQuery(c));

            CreateMap<Belt, BeltVM>();
            CreateMap<Person, PersonVM>();
        }
    }
}