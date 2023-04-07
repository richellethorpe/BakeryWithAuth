using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Bakery.Models;


namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
      private readonly BakeryContext _db;
      public HomeController(BakeryContext db)
      {
        _db = db;
      }


    [HttpGet("/")]
    public ActionResult Index()
    {
        Treat[] treats = _db.Treats.ToArray();
        Flavor[] flavors = _db.Flavors.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string,object[]>();
        model.Add("treats", treats);
        model.Add("flavors", flavors);
        return View(model);
    }
  }
}