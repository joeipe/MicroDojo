using AutoMapper;
using MicroDojoPurchase.Read.Domain;
using MicroDojoPurchase.ViewModels;

namespace MicroDojoPurchase.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Stock, StockVM>();
            CreateMap<Person, PersonVM>();
            CreateMap<Order, OrderVM>();
        }
    }
}