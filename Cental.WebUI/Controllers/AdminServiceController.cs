using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminServiceController(IServicesService _servicesService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var services = _servicesService.TGetAll();
            var serviceDtos = _mapper.Map<List<ResultServiceDto>>(services);

            return View(serviceDtos);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {

            var service = _mapper.Map<Service>(createServiceDto);
            _servicesService.TCreate(service);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var service = _servicesService.TGetById(id);
            if (service == null)
            {
                return NotFound();
            }
            var serviceDto = _mapper.Map<UpdateServiceDto>(service);
            return View(serviceDto);
        }

        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto model)
        {
            var services = _mapper.Map<Service>(model);
            _servicesService.TUpdate(services);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteService(int id)
        {
            _servicesService.TDelete(id);
            return RedirectToAction("Index");
        }

    }
}
