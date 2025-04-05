using lab2.Models.AuthModels;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
