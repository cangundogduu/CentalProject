using AutoMapper;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ReviewMapping:Profile
    {
        public ReviewMapping()
        {
            CreateMap<Review, ResultReviewDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
        }
    }
}
