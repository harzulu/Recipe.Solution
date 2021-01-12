using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<IngredientRecipe>();
        }

        public int IngredientId { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientRecipe> Recipes { get;}
    }
}