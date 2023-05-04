using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}