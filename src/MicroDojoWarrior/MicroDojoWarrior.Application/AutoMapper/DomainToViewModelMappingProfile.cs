using AutoMapper;
using MicroDojoWarrior.Read.Domain;
using MicroDojoWarrior.ViewModels;

namespace MicroDojoWarrior.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Belt, BeltVM>();
            CreateMap<Person, PersonVM>();
        }
    }
}