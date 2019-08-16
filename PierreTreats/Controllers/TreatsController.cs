using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PierreTreats.Models;
//new code
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierreTreats.Controllers
{
    [Authorize]
    public class TreatsController : Controller
    {
        private readonly PierreTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(PierreTreatsContext db, UserManager<ApplicationUser> usermanager)
        {
            _db = db;
            _userManager = usermanager;
        }

        public async Task<ActionResult> Index()
        {

            return View(_db.Treats.ToList()); //dont need toList here? where return list maybe.
        }
        public ActionResult Details(int id)
        {
            var model = _db.Treats
            .Include(treat => treat.Flavors)
            .ThenInclude(join => join.Flavor)
            .FirstOrDefault(treat => treat.TreatId == id);
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Treat treat)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            treat.User = currentUser;
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddFlavor(int id)
        {
            var thisItem = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int FlavorId)
        {
            Console.WriteLine(treat.ToString());
            if (FlavorId != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}