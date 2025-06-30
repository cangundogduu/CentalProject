using AutoMapper;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ProcessMapping : Profile
    {
        public ProcessMapping()
        {
            CreateMap<Process, CreateProcessDto>().ReverseMap();
            CreateMap<Process, UpdateProcessDto>().ReverseMap();
            CreateMap<Process, ResultProcessDto>().ReverseMap();
        }
    }
}
