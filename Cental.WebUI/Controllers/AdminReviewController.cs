using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminReviewController(IReviewService _reviewService,
                                       ICarService _carService,
                                       IMapper _mapper,
                                       UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
            var reviews = _reviewService.TGetAll();
            var results = _mapper.Map<List<ResultReviewDto>>(reviews);
            return View(results);
        }



        private void SelectCarList()
        {
            var cars = _carService.TGetAll();
            var carList = (from car in cars
                           select new SelectListItem
                           {
                               Text = car.Brand.BrandName + " " + car.ModelName + " " + car.Year,
                               Value = car.CarId.ToString()
                           }).ToList();
            ViewBag.CarList = carList;
        }

        private void SelectUserList()
        {
            var users = _userManager.Users.ToList();
            var userList = (from user in users
                            select new SelectListItem
                            {
                                Text = user.FirstName + " " + user.LastName + " " + "(" + user.UserName + ")",
                                Value = user.Id.ToString()
                            }).ToList();
            ViewBag.UserList = userList;
        }





        public IActionResult DeleteReview(int id)
        {
            var review = _reviewService.TGetById(id);
            if (review != null)
            {
                _reviewService.TDelete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult UpdateReview(int id)
        {
            SelectCarList();
            SelectUserList();
            var review = _reviewService.TGetById(id);
            if (review != null)
            {
                var result = _mapper.Map<UpdateReviewDto>(review);
                return View(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateReview(UpdateReviewDto updateReviewDto)
        {
           
                var review = _mapper.Map<Review>(updateReviewDto);
                _reviewService.TUpdate(review);
                return RedirectToAction("Index");
            
        }

        public IActionResult CreateReview()
        {
            SelectCarList();
            SelectUserList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(CreateReviewDto createReviewDto)
        {
            
                var review = _mapper.Map<Review>(createReviewDto);
                _reviewService.TCreate(review);
                return RedirectToAction("Index");
        }
    }
}
