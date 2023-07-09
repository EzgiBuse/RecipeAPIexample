using RecipeAPIexample.Models;

namespace RecipeAPIexample.Data
{
    public static class RecipeStore
    {
        public static List<Recipe> recipeList = new List<Recipe>
            {
                new Recipe{Id=1,Name="Pizza",Cuisine="Italian"},
                new Recipe{Id=2,Name="Pasta",Cuisine="Italian"},
                new Recipe { Id = 3, Name = "Croissant", Cuisine = "French" },
                new Recipe { Id = 4, Name = "Lahmacun", Cuisine = "Turkish" }
            };
    }
}
