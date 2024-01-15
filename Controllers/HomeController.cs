using BusinessMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessMVC.Controllers
{
    public class HomeController : Controller
    {
        BusinessContext _db { get; }

        public HomeController(BusinessContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
