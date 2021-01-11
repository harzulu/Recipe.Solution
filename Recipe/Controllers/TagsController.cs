using Microsoft.AspNetCore.Mvc;
using Recipe.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Recipe.Controllers
{
  public class TagsController : Controller
  {
    private readonly RecipeContext _db;

    public TagsController(RecipeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Tag Tag, int RecipeId)
    {
      return View();
    }

    public ActionResult Details(int id)
    {
      return View();
    }

    public ActionResult Edit(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(x => x.TagId == id);
    return View(thisTag);
    }

    [HttpPost]
    public ActionResult Edit(Tag Tag, int RecipeId)
    {
      return View();
    }

    public ActionResult AddRecipe(int id)
    {
      return View();
    }

    [HttpPost]
    public ActionResult AddRecipe(Tag Tag, int RecipeId)
    {
      return View();
    }

    public ActionResult Delete(int id)
    {
      return View();
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      return View();
    }

    [HttpPost]
    public ActionResult DeleteRecipe(int joinId)
    {
      return View();
    }
  }
}