using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminFeatureController(IFeatureService _featureService, IMapper _mappper) : Controller
    {
        public IActionResult Index()
        {
            var features = _featureService.TGetAll();
            var values = _mappper.Map<List<ResultFeatureDto>>(features);
            return View(values);
        }

        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto model)
        {

            var newFeature = _mappper.Map<Feature>(model);
            _featureService.TCreate(newFeature);
            return RedirectToAction("Index");

        }

        public IActionResult UpdateFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            var values = _mappper.Map<UpdateFeatureDto>(feature);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDto model)
        {
            var updatedFeature = _mappper.Map<Feature>(model);
            _featureService.TUpdate(updatedFeature);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
