using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCarController(ICarService _carService,IMapper _mapper,IBrandService _brandService) : Controller
    {
        public IActionResult Index()
        {
            var values = _carService.TGetAll();

            return View(values);
        }

        public IActionResult CreateCar()
        {
            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissionTypes = GetEnumValues.GetEnums<Transmissions>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text= x.BrandName,
                                  Value= x.BrandId.ToString()
                              }).ToList();


            return View();
        }

        [HttpPost]
        public IActionResult CreateCar(CreateCarDto model)
        {
            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissionTypes = GetEnumValues.GetEnums<Transmissions>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandId.ToString()
                              }).ToList();


            var newCar= _mapper.Map<Car>(model);
            _carService.TCreate(newCar);
            return RedirectToAction("Index");
        }
    }
}
