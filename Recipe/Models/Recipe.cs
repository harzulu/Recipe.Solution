using System.Collections.Generic;

namespace Recipe.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Tags = new HashSet<RecipeTag>();
            this.Ingredients = new HashSet<IngredientRecipe>();
        }

        public int RecipeId { get; set; }
        public string Title { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<RecipeTag> Tags { get; set; }
        public virtual ICollection<IngredientRecipe> Ingredients { get; set; }
    }
}