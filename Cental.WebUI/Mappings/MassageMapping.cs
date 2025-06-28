using AutoMapper;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class MassageMapping: Profile
    {
        public MassageMapping()
        {
            CreateMap<Message,ResultMessageDto>().ReverseMap();
            CreateMap<Message,UpdateMessageDto>().ReverseMap();
            CreateMap<Message,CreateMessageDto>().ReverseMap();
            CreateMap<Message,DetailMessageDto>().ReverseMap();

        }
    }
    
}
