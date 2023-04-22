using ApplicationLayer.Models;
using DataLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public DrinkController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{urlSlug}")]
        public IActionResult Detail(string urlSlug)
        {
            var viewModel = new DrinkViewModel();
            //viewModel.Drink =
            return View();
        }
    }
}