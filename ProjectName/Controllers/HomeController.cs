using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ProjectName.Controllers
{
    public class HomeController : Controller
    {
      private readonly ProjectNameContext _db;

      public HomeController(ProjectNameContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        ViewBag.Categories = _db.Categories.ToList();
        ViewBag.Items = _db.Items.ToList();
        return View();
      }

    }
}