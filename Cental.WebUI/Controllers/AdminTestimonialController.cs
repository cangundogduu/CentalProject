using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDto;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTestimonialController(ITestimonialService _testimonialService, IMapper _mapper, IImageService _imageService) : Controller
    {
        public IActionResult Index()
        {
            var testimonials = _testimonialService.TGetAll();
            var mappedTestimonials = _mapper.Map<List<ResultTestimonialDto>>(testimonials);

            return View(mappedTestimonials);
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {

            var mappedTestimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            if (createTestimonialDto.ImageFile != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(createTestimonialDto.ImageFile);
                mappedTestimonial.ImageUrl = imageUrl;
            }
            _testimonialService.TCreate(mappedTestimonial);

            return RedirectToAction("Index");

        }

        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            var mappedTestimonial = _mapper.Map<UpdateTestimonialDto>(testimonial);
            return View(mappedTestimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var mappedTestimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            if (updateTestimonialDto.ImageFile != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(updateTestimonialDto.ImageFile);
                mappedTestimonial.ImageUrl = imageUrl;
            }
            _testimonialService.TUpdate(mappedTestimonial);

            return RedirectToAction("Index");
        }
    }
}
