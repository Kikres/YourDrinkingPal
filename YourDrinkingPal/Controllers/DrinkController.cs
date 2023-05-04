using ApplicationLayer.Models;
using BusinessLayer.Models.DTO;
using BusinessLayer.Services;
using DataLayer.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("[controller]")]
    public class DrinkController : Controller
    {
        private readonly ServiceDrink _serviceDrink;
        private readonly ServiceFlavour _serviceFlavour;
        private readonly ServiceTag _serviceTag;
        private readonly ServiceGlass _serviceGlas;
        private readonly ServiceUnit _serviceUnit;
        private readonly ServiceIngridient _serviceIngridient;
        private readonly ServiceTransparency _serviceTransparency;
        private readonly ServiceColor _serviceColor;
        private readonly ServiceGarnish _serviceGarnish;
        private readonly ServiceTool _serviceTool;
        private readonly ServiceGeneratedImage _serviceGeneratedImage;
        private readonly UserManager<ApplicationUser> _userManager;

        public DrinkController(ServiceDrink serviceDrink,
                               ServiceFlavour serviceFlavour,
                               ServiceTag serviceTag,
                               ServiceGlass serviceGlas,
                               ServiceUnit serviceUnit,
                               ServiceIngridient serviceIngridient,
                               ServiceTransparency serviceTransparency,
                               ServiceColor serviceColor,
                               ServiceGarnish serviceGarnish,
                               ServiceTool serviceTool,
                               UserManager<ApplicationUser> userManager,
                               ServiceGeneratedImage serviceGeneratedImage)
        {
            _serviceDrink = serviceDrink;
            _serviceFlavour = serviceFlavour;
            _serviceTag = serviceTag;
            _serviceGlas = serviceGlas;
            _serviceUnit = serviceUnit;
            _serviceIngridient = serviceIngridient;
            _serviceTransparency = serviceTransparency;
            _serviceColor = serviceColor;
            _serviceGarnish = serviceGarnish;
            _serviceTool = serviceTool;
            _userManager = userManager;
            _serviceGeneratedImage = serviceGeneratedImage;
        }

        [HttpGet("detail/{urlSlug}")]
        public IActionResult Detail(string urlSlug)
        {
            var drink = _serviceDrink.GetByUrlSlug(urlSlug, true);
            if (drink == null) return RedirectToAction("Index", "");
            var viewModel = new DrinkViewModel() { Drink = drink };
            return View(viewModel);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var flavours = _serviceFlavour.GetAll().OrderBy(o => o.Name).ToList();
            var tags = _serviceTag.GetAll().OrderBy(o => o.Name).ToList();
            var glasses = _serviceGlas.GetAll().OrderBy(o => o.Name).ToList();
            var units = _serviceUnit.GetAll().OrderBy(o => o.Name).ToList();
            var ingridients = _serviceIngridient.GetAll().OrderBy(o => o.Name).ToList();
            var transparencies = _serviceTransparency.GetAll();
            var color = _serviceColor.GetAll();
            var garnish = _serviceGarnish.GetAll().OrderBy(o => o.Name).ToList();
            var equipment = _serviceTool.GetAll().OrderBy(o => o.Name).ToList();

            var viewModel = new DrinkCreateViewModel()
            {
                DrinkCreateDto = new DrinkCreateDto() { Recipe = new RecipeDto() { Measurements = new List<MeasurementDto>(), Instructions = new List<InstructionDto>(), Equipment = new List<ToolDto>() } },
                Flavours = flavours,
                Tags = tags,
                Glasses = glasses,
                Units = units,
                Ingridients = ingridients,
                Transparencies = transparencies,
                Colors = color,
                Garnishes = garnish,
                Equipment = equipment,
            };

            viewModel.DrinkCreateDto.Recipe.Measurements.Add(new MeasurementDto());
            viewModel.DrinkCreateDto.Recipe.Instructions.Add(new InstructionDto());
            viewModel.DrinkCreateDto.Recipe.Equipment.Add(new ToolDto());

            return View(viewModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(DrinkCreateDto drinkCreateDto)
        {
            drinkCreateDto.Creator = await _userManager.GetUserAsync(User);

            var drinkDto = await _serviceDrink.Create(drinkCreateDto);

            if (drinkDto == null) return BadRequest();

            return Redirect($"preview/{drinkDto.Id}");
        }

        [HttpGet("preview/{id}")]
        public async Task<IActionResult> Preview(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var drink = _serviceDrink.GetById(id, true);

            if (drink == null || drink.IsPublished || drink.Creator.Id != user.Id) return RedirectToAction("Index", "");

            var generatedImage = _serviceGeneratedImage.GetByDrinkId(drink.Id);

            var viewModel = new DrinkPreviewViewModel()
            {
                Drink = drink,
                GeneratedImageDto = generatedImage,
            };

            return View(viewModel);
        }

        [HttpPost("preview/{id}")]
        public async Task<IActionResult> Preview(DrinkPublishDto drinkPublishDto, int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var isOwner = _serviceDrink.UserIsOwner(user, id);
            var isPublished = _serviceDrink.IsPublished(id);
            if (!isOwner || isPublished) return RedirectToAction("Index", "");

            var drink = _serviceDrink.PublishDrink(drinkPublishDto);

            return RedirectToAction("detail", "drink", new { drink.UrlSlug });
        }
    }
}