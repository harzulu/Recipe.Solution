using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Recipe.Models
{
  public class RecipeContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTag { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientRecipe> IngredientRecipe { get; set; }

    public RecipeContext(DbContextOptions options) : base(options) { }
  }
}