using Microsoft.AspNetCore.Mvc;
using Recipe.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Recipe.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeContext _db;

    public RecipesController(RecipeContext db)
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

    // [HttpPost]
    // public ActionResult Create()
    // {
    //   return View();
    // }

    public ActionResult Details(int id)
    {
      return View();
    }

    public ActionResult Edit(int id)
    {
      return View();
    }

    [HttpPost]
    public ActionResult Edit()
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
  }
}