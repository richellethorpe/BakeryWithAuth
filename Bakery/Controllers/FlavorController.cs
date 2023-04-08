using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bakery.Controllers
{
  public class FlavorController : Controller
  {
    private readonly BakeryContext _db;

    public FlavorController(BakeryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors 
                          .Include(flavor => flavor.TreatFlavors)
                          .ThenInclude(join => join.Treat)
                          .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    public ActionResult AddTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault( flavors => flavors.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
      #nullable enable
      TreatFlavor? treatFlavor = _db.TreatFlavors.FirstOrDefault(join => (join.TreatId  == treatId && join.FlavorId == flavor.FlavorId));
      #nullable disable
      if (treatFlavor == null && treatId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treatId, FlavorId = flavor.FlavorId});
        _db.SaveChanges();
      }
      return RedirectToAction( "Details", new { id = flavor.FlavorId});
    }

  }
}