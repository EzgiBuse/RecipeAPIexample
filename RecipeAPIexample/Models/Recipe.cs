using System.ComponentModel.DataAnnotations;

namespace RecipeAPIexample.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        public string Cuisine { get; set; }
    }
}
