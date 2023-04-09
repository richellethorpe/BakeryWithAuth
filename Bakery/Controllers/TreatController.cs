using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Bakery.Controllers
{
  
  public class TreatController : Controller
  {
    private readonly BakeryContext _db;

    public TreatController(BakeryContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
     }
    }

    [AllowAnonymous]
    public ActionResult Details( int id)
    {
      Treat thisTreat = _db.Treats
                        .Include(treat => treat.TreatFlavors)
                        .ThenInclude(join => join.Flavor)
                        .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult AddFlavor(int id)

    {
      Treat thisTreat = _db.Treats.FirstOrDefault( treats => treats.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
      #nullable enable
      TreatFlavor? treatFlavor = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId  == flavorId && join.TreatId == treat.TreatId));
      #nullable disable
      if (treatFlavor == null && flavorId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavorId, TreatId = treat.TreatId});
        _db.SaveChanges();
      }
      return RedirectToAction( "Details", new { id = treat.TreatId});
    }

    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}