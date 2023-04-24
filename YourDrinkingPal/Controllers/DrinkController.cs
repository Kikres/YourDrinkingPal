using ApplicationLayer.Models;
using Business_Layer.Services;
using BusinessLayer.Models.DTO;
using DataLayer.Data;
using DataLayer.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ServiceDrink _serviceDrink;
        private readonly ServiceFlavour _serviceFlavour;
        private readonly ServiceTag _serviceTag;
        private readonly ServiceGlass _serviceGlas;
        private readonly ServiceUnit _serviceUnit;
        private readonly ServiceIngridient _serviceIngridient;

        public DrinkController(ServiceDrink serviceDrink, ServiceFlavour serviceFlavour, ServiceTag serviceTag, ServiceGlass serviceGlas, ServiceUnit serviceUnit, ServiceIngridient serviceIngridient)
        {
            _serviceDrink = serviceDrink;
            _serviceFlavour = serviceFlavour;
            _serviceTag = serviceTag;
            _serviceGlas = serviceGlas;
            _serviceUnit = serviceUnit;
            _serviceIngridient = serviceIngridient;
        }

        [HttpGet("drink/detail/{urlSlug}")]
        public IActionResult Detail(string urlSlug)
        {
            var drink = _serviceDrink.GetByUrlSlug(urlSlug, true);
            if (drink == null) return RedirectToAction("Index", "");
            var viewModel = new DrinkViewModel() { Drink = drink };
            return View(viewModel);
        }

        [HttpGet("drink/create")]
        public IActionResult Create()
        {
            var flavours = _serviceFlavour.GetAll();
            var tags = _serviceTag.GetAll();
            var glasses = _serviceGlas.GetAll();
            var units = _serviceUnit.GetAll();
            var ingridients = _serviceIngridient.GetAll();

            var viewModel = new DrinkCreateViewModel()
            {
                Drink = new DrinkDto(),
                Flavours = flavours,
                Tags = tags,
                Glasses = glasses,
                Units = units,
                Ingridients = ingridients,
            };
            viewModel.Drink.Recipe.Measurements.Add(new MeasurementDto());
            viewModel.Drink.Recipe.Instructions.Add(new InstructionDto());

            return View(viewModel);
        }

        [HttpPost("drink/create")]
        public IActionResult Create(DrinkDto drink)
        {
            return RedirectToRoute("/");
        }
    }
}