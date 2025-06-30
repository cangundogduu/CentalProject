using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProcessController(IProcessService _processService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = _processService.TGetAll();
            var results = _mapper.Map<List<ResultProcessDto>>(values);
            return View(results);
        }

        public IActionResult DeleteProcess(int id)
        {
            var process = _processService.TGetById(id);
            if (process != null)
            {
                _processService.TDelete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult UpdateProcess(int id)
        {
            var process = _processService.TGetById(id);
            if (process != null)
            {
                var result = _mapper.Map<UpdateProcessDto>(process);
                return View(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateProcess(UpdateProcessDto updateProcessDto)
        {
            if (ModelState.IsValid)
            {
                var process = _mapper.Map<Process>(updateProcessDto);
                _processService.TUpdate(process);
                return RedirectToAction("Index");
            }
            return View(updateProcessDto);
        }

        public IActionResult CreateProcess()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProcess(CreateProcessDto createProcessDto)
        {
            if (ModelState.IsValid)
            {
                var process = _mapper.Map<Process>(createProcessDto);
                _processService.TCreate(process);
                return RedirectToAction("Index");
            }
            return View(createProcessDto);
        }
    }
}
