using AutoMapper;

namespace PetStore.API
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Core.Entities.Order, Core.Models.Order>();

            CreateMap<Core.Entities.OrderItem, Core.Models.OrderItem>();

            CreateMap<Core.Models.OrderForCreation, Core.Entities.Order>();

            CreateMap<Core.Models.OrderItemForCreation, Core.Entities.OrderItem>();

            CreateMap<Core.Models.ProductDetail, Core.Entities.OrderItem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price));
        }
    }
}
