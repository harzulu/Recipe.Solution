using RecipeBook.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBook.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly RecipeBookContext _db;
    
    public IngredientsController(RecipeBookContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Ingredient> model = _db.Ingredients.ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      var thisIngredient = _db.Ingredients
        .Include(ingredient => ingredient.Recipes)
        .ThenInclude(join => join.Recipe)
        .FirstOrDefault(ingredient => ingredient.IngredientId == id);
        return View (thisIngredient);
    }

    public ActionResult Create()
    {
        ViewBag.IngredientId = new SelectList(_db.Recipes, "IngredientId", "Title");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Ingredient ingredient, int RecipeId)
    {
        _db.Ingredients.Add(ingredient);
        if (RecipeId != 0)
        {
            _db.IngredientRecipe.Add(new IngredientRecipe() { RecipeId = RecipeId, IngredientId = ingredient.IngredientId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
        ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Title");
        return View(thisIngredient);
    }

    [HttpPost]
    public ActionResult Edit(Ingredient ingredient, int RecipeId)
    {
      if (RecipeId !=0)
    {
      _db.IngredientRecipe.Add(new IngredientRecipe() { RecipeId = RecipeId, IngredientId = ingredient.IngredientId });
    }
        _db.Entry(ingredient).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
        return View(thisIngredient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
        _db.Ingredients.Remove(thisIngredient);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}