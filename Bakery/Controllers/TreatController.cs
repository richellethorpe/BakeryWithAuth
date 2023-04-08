using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;

namespace TreatFood.Controllers
{
  public class TreatController : Controller
  {
    private readonly BakeryContext _db;

    public TreatController(BakeryContext db)
    {
      _db = db;
    }

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


    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats 
                          .Inclue(treat => treat.JoinEntity)
                          .ThenInclude(join => join.Flavor)
                          .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult AddFlavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisTreat);
    }
     
    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
    #nullable enable
    TreatFlavor? treatFlavor = _db.JoinEntity.FirstOrDefault(TreatFlavor => (TreatFlavor.FlavorId == flavorId && TreatFlavor.TreatId == treat.TreatId));
    #nullable disable
    if(treatFlavor == null && flavorId !=0)
    {
    _db.JoinEntity.Add(new TreatFlavor() {TreatId = treat.TreatId, FlavorId = flavorId});
    _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = treat.TreatId});
    }

  }
}