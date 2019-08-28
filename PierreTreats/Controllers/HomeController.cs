using Microsoft.AspNetCore.Mvc;
using PierreTreats.Models;

namespace PierreTreats.Controllers
{
    public class HomeController : Controller
    {
        private readonly PierreTreatsContext _db;

        public HomeController(PierreTreatsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}