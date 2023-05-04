using ApplicationLayer.Models;
using BusinessLayer;
using BusinessLayer.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly Service _service;

        public HomeController(Service service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var drinks = _service.Drink.GetAllPublished(true);

            if (!drinks.Any())
            {
                drinks.Add(new DrinkDto()
                {
                    Id = 1,
                    Name = "Test ifall tomt",
                    UrlSlug = "Test",
                    Tag = new TagDto { Id = 1, Name = "Test Tag" },
                });
            }

            var homeViewModel = new HomeViewModel
            {
                Drinks = drinks
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}