using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Recipes = new HashSet<RecipeTag>();
        }

        public int TagId { get; set; }
        public string Category { get; set; }

        public ICollection<RecipeTag> Recipes { get;}
    }
}