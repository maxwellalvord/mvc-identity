using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace ProjectName.Controllers
{
  [Authorize]
  public class CategoriesController : Controller
  {
    private readonly ProjectNameContext _db;

    private readonly UserManager<ApplicationUser> _userManager;

    public CategoriesController(UserManager<ApplicationUser> userManager, ProjectNameContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [AllowAnonymous] 
    public ActionResult Index()
    {

      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Category category)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      category.User = currentUser;
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisCategory = _db.Categories
          .Include(category => category.JoinEntities)
          .ThenInclude(join => join.Item)
          .FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }
    public ActionResult Edit(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddItem(int id)
    {
        var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
        ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Name");
        return View(thisCategory);
    }
    [HttpPost]
    public ActionResult AddItem(Category category, int ItemId)
    {
        if (ItemId != 0)
        {
          _db.CategoryItem.Add(new CategoryItem() { ItemId = ItemId, CategoryId = category.CategoryId });
          _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteItem(int joinId)
    {
        var joinEntry = _db.CategoryItem.FirstOrDefault(entry => entry.CategoryItemId == joinId);
        _db.CategoryItem.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}