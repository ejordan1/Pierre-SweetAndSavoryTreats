using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierreTreats.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierreTreats.Controllers
{
    public class TreatsController : Controller
    {
        private readonly PierreTreatsContext _db;

        public TreatsController (PierreTreatsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            Console.WriteLine("INDEX OF TrEAT CONTROLLER");
            var model = _db.Treats.ToList();
            Console.WriteLine(model.ToString());
            return View(_db.Treats.ToList());
        }
        public ActionResult Details (int id)
        {
            var model = _db.Treats
            .Include(treat => treat.FlavorTreats)
            .ThenInclude(join => join.Flavor)
            .FirstOrDefault(treat => treat.TreatId == id);
            return View(model);
        }

        public ActionResult Create ()
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
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