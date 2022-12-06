using AutoMapper;
using Links_Clients.Models;

namespace Links_Clients.Helpers
{
    public class ClientsMapper : Profile
    {
        public ClientsMapper() 
        {
            CreateMap<Client_Raw, Client_Internal>();
            CreateMap<Client_Raw, Client_Simplified>();
            CreateMap<Client_Raw, Client_Public>();
            CreateMap<Client_Internal, Client_Raw>().ForMember(dest => dest.Id, src => src.Ignore());
            CreateMap<Client_Internal, Client_Public>();
            CreateMap<Client_Public, Client_Raw>().ForMember(dest => dest.Id, src => src.Ignore());
            //CreateMap<Client_Public, Client_Raw>().ForMember(dest => dest.Avatar, act => act.MapFrom(src => src.Avatar));
            CreateMap<Client_Public, Client_Internal>();
        }
    }
}
