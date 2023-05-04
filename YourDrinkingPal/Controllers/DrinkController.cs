using ApplicationLayer.Models;
using BusinessLayer;
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
        private readonly Service _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public DrinkController(Service service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("detail/{urlSlug}")]
        public IActionResult Detail(string urlSlug)
        {
            if (!_service.Drink.ExistsByUrlSlug(urlSlug)) return RedirectToAction("Index", "");

            var drink = _service.Drink.GetByUrlSlug(urlSlug, true);

            var viewModel = new DrinkDetailViewModel() { Drink = drink };

            return View(viewModel);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var flavours = _service.Flavour.GetAll().OrderBy(o => o.Name).ToList();
            var tags = _service.Tag.GetAll().OrderBy(o => o.Name).ToList();
            var glasses = _service.Glass.GetAll().OrderBy(o => o.Name).ToList();
            var units = _service.Unit.GetAll().OrderBy(o => o.Name).ToList();
            var ingridients = _service.Ingridient.GetAll().OrderBy(o => o.Name).ToList();
            var transparencies = _service.Transparency.GetAll();
            var color = _service.Color.GetAll();
            var garnish = _service.Garnish.GetAll().OrderBy(o => o.Name).ToList();
            var equipment = _service.Tool.GetAll().OrderBy(o => o.Name).ToList();

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
            if (_service.Drink.VerifyDrinkCreateDto(drinkCreateDto)) return BadRequest();

            //drinkCreateDto.Creator = await _userManager.GetUserAsync(User);

            var drinkDto = await _service.Drink.Create(drinkCreateDto);

            if (drinkDto == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Redirect($"preview/{drinkDto.Id}");
        }

        [HttpGet("preview/{id}")]
        public async Task<IActionResult> Preview(int id)
        {
            //var user = await _userManager.GetUserAsync(User);
            //var isOwner = _service.Drink.UserIsOwner(user, id);
            var drink = _service.Drink.GetById(id, true);
            if (drink == null || drink.IsPublished /*|| isOwner*/) return RedirectToAction("Index", "");

            var generatedImage = _service.GeneratedImage.GetByDrinkId(drink.Id);
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
            //var user = await _userManager.GetUserAsync(User);
            //var isOwner = _service.Drink.UserIsOwner(user, id);
            var isPublished = _service.Drink.IsPublished(id);
            if (/*!isOwner ||*/ isPublished) return RedirectToAction("Index", "");

            var drink = _service.Drink.PublishDrink(drinkPublishDto);

            return RedirectToAction("detail", "drink", new { drink.UrlSlug });
        }
    }
}