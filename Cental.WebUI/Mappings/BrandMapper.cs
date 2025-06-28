using AutoMapper;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BrandMapper:Profile
    {
        public BrandMapper()
        {
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
        }
    }
}
