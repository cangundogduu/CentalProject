using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBookingController(IBookingService _bookingService,
                                        IMapper _mapper,
                                        UserManager<AppUser> _userManager,
                                        ICarService _carService) : Controller
    {
        public IActionResult Index()
        {
            var values = _bookingService.TGetAll();
            var booking = _mapper.Map<List<ResultBookingDto>>(values);
            return View(booking);
        }

        private List<SelectListItem> GetUserSelectedList()
        {
            var users = (from x in _userManager.Users
                         select new SelectListItem
                         {
                             Text = x.FirstName + " " + x.LastName,
                             Value = x.Id.ToString()
                         }).ToList();
            return users;
        }

        private List<SelectListItem> GetCarSelectedList()
        {
            var cars = (from x in _carService.TGetAll()
                        select new SelectListItem
                        {
                            Text = x.ModelName + " " + x.Brand + "" + x.Year,
                            Value = x.CarId.ToString()

                        }).ToList();
            return cars;
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            ViewBag.Users = GetUserSelectedList();
            ViewBag.Cars = GetCarSelectedList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
            booking.Status = "Onay Bekliyor";
            booking.IsApproved = null;
            _bookingService.TCreate(booking);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateBooking(int id)
        {
            var booking = _bookingService.TGetById(id);
            var bookingDto = _mapper.Map<UpdateBookingDto>(booking);
            ViewBag.Users = GetUserSelectedList();
            ViewBag.Cars = GetCarSelectedList();
            return View(bookingDto);
        }

        [HttpPost]
        public IActionResult UpdateBooking(UpdateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
            if (booking.IsApproved == true)
            {
                booking.Status = "Onaylandı";
            }
            else if (booking.IsApproved == false)
            {
                booking.Status = "Reddedildi";
            }
            else
            {
                booking.Status = "Onay Bekliyor";
            }
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteBooking(int id)
        {
            _bookingService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ApproveRezervation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = true;
            booking.Status = "Onaylandı";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeclineRezervation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = false;
            booking.Status = "Reddedildi";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult WaitingRezervation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = null;
            booking.Status = "Beklemede";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }
    }
}
