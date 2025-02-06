using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cental.WebUI.Controllers
{
    public class CarsController(ICarService _carService, IBrandService _brandService, CentalContext _context) : Controller
    {
        public IActionResult Index()
        {
            var data = TempData["filterCars"].ToString();
            if (data==null)
            {
                var valuess = _carService.TGetAll();
                return View(valuess);
            }

            var filterCars = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });

            var values = _carService.TGetAll();
            return View();
        }

        public PartialViewResult FilterCars()
        {
            var cars = _carService.TGetAll();

            ViewBag.cars = (from x in cars
                            select new SelectListItem
                            {
                                Text = x.Brand.BrandName + " " + x.ModelName,
                                Value = x.Brand.BrandName + " " + x.ModelName
                            }).ToList();

            //ViewBag.models = (from x in _carService.TGetAll()
            //                  select new SelectListItem
            //                  {
            //                      Text = x.ModelName,
            //                      Value = x.ModelName
            //                  }).ToList();

            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();

            return PartialView();
        }

        [HttpPost]
        public IActionResult FilterCars(string car, string gear, int year, string gas)
        {
            if (string.IsNullOrEmpty(car) || string.IsNullOrEmpty(gear) || string.IsNullOrEmpty(gas) || year > 0)
            {
                var values = _context.Cars.Where(x => x.Brand.BrandName + " " + x.ModelName == car &&
                                                 x.GearType == gear &&
                                                 x.GasType == gas &&
                                                 x.Year >= year).ToList();

                TempData["filterCars"]= JsonSerializer.Serialize(values,new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });
                
            }
            return RedirectToAction("Index");
        }
    }
}
