using AutoMapper;
using Links_Cards.Models;

namespace Links_Cards.Helpers
{
    public class CardsMapper : Profile
    {
        public CardsMapper() 
        {
            CreateMap<Card_Raw, Card_Internal>();
            CreateMap<Card_Raw, Card_Public>();
            CreateMap<Card_Internal, Card_Raw>().ForMember(dest => dest.Id, src => src.Ignore());
            CreateMap<Card_Internal, Card_Public>();
            CreateMap<Card_Public, Card_Raw>().ForMember(dest => dest.Id, src => src.Ignore());
            //CreateMap<Card_Public, Card_Raw>().ForMember(dest => dest.Avatar, act => act.MapFrom(src => src.Avatar));
            CreateMap<Card_Public, Card_Internal>();
        }
    }
}
