using AutoMapper;
using MicroDojoWarrior.ViewModels;
using MicroDojoWarrior.Write.Data.Commands;

namespace MicroDojoWarrior.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BeltVM, BeltAddCommand>()
                .ConvertUsing(c => new BeltAddCommand(c.Color));

            CreateMap<BeltVM, BeltUpdateCommand>()
                .ConvertUsing(c => new BeltUpdateCommand(c.Id, c.Color));

            CreateMap<int, BeltDeleteCommand>()
                .ConvertUsing(c => new BeltDeleteCommand(c));

            CreateMap<PersonVM, PersonAddCommand>()
                .ConvertUsing(c => new PersonAddCommand(c.FirstName, c.LastName, c.DateOfBirth, c.Address, c.BeltId, c.Stripes));

            CreateMap<PersonVM, PersonUpdateCommand>()
                .ConvertUsing(c => new PersonUpdateCommand(c.Id, c.FirstName, c.LastName, c.DateOfBirth, c.Address, c.BeltId, c.Stripes));

            CreateMap<int, PersonDeleteCommand>()
                .ConvertUsing(c => new PersonDeleteCommand(c));
        }
    }
}