using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBook.Controllers
{
  public class InstructionsController : Controller
  {
    private readonly RecipeBookContext _db;

    public InstructionsController(RecipeBookContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Instructions.ToList());
    }

    public ActionResult Create(int id)
    {
      ViewBag.RecipeId = id;
      return View();
    }

    [HttpPost]
    public ActionResult Create(Instruction instruction, int RecipeId)
    {
      instruction.RecipeId = RecipeId;
      _db.Instructions.Add(instruction);
      _db.SaveChanges();
      return RedirectToAction("Create", new { id = RecipeId});
    }

    public ActionResult Details(int id)
    {
      Instruction thisInstruction = _db.Instructions
        .FirstOrDefault(Instruction => Instruction.InstructionId == id);
      return View(thisInstruction);
    }

    public ActionResult Edit(int id)
    {
      var thisInstruction = _db.Instructions.FirstOrDefault(Instructions => Instructions.InstructionId == id);
      return View(thisInstruction);
    }

    [HttpPost]
    public ActionResult Edit(Instruction Instruction)
    {
      _db.Entry(Instruction).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisInstruction = _db.Instructions.FirstOrDefault(Instructions => Instructions.InstructionId == id);
      return View(thisInstruction);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisInstruction = _db.Instructions.FirstOrDefault(Instructions => Instructions.InstructionId == id);
      _db.Instructions.Remove(thisInstruction);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}