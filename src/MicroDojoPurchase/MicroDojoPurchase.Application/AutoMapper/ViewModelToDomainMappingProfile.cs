using AutoMapper;
using MicroDojoPurchase.ViewModels;
using MicroDojoPurchase.Write.Domain;

namespace MicroDojoPurchase.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StockVM, Stock>();
            CreateMap<PersonVM, Person>();
            CreateMap<OrderVM, Order>();
        }
    }
}