using RecipeBook.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace RecipeBook.Controllers
{
  public class HomeController : Controller
  {

    private readonly RecipeBookContext _db;

    public HomeController(RecipeBookContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(string SearchTerm, string SearchOption)
    {
      if (SearchOption == "Tag")
      {
        var tags = _db.Tags;
        foreach (var tag in tags)
        {
          if (tag.Category == SearchTerm)
          {
            return RedirectToAction("Details", "Tags", new { id = tag.TagId });
          }
        }
      }
      else if (SearchOption == "Ingredient")
      {
        var ingredients = _db.Ingredients;
        foreach (var ingredient in ingredients)
        {
          if (ingredient.Name == SearchTerm)
          {
            return RedirectToAction("Details", "Ingerdients", new { id = ingredient.IngredientId });
          }
        }
      }
      return View();
    }
  }
}