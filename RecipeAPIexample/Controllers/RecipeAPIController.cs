using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeAPIexample.Data;
using RecipeAPIexample.Models;

namespace RecipeAPIexample.Controllers
{
    // A basic CRUD API project example
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetRecipes()
        {
            return Ok(RecipeStore.recipeList);

        }

        [HttpGet("ID")]
        public ActionResult<Recipe> GetRecipe(int ID)
        {
            if(ID == 0)
            {
                return BadRequest();
            }
            
            return Ok(RecipeStore.recipeList.FirstOrDefault(u => u.Id == ID));

        }

        [HttpPost]
        
        public ActionResult<Recipe> CreateRecipe([FromBody]Recipe recipe)
        {
            if(recipe == null)
            {
                return BadRequest(recipe);
            }
            if(recipe.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            recipe.Id = RecipeStore.recipeList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            RecipeStore.recipeList.Add(recipe);
            return Ok(recipe);  
        }

        [HttpDelete("ID")]
        public IActionResult DeleteRecipe(int ID)
        {
            var recipe = RecipeStore.recipeList.FirstOrDefault(u => u.Id == ID);
            RecipeStore.recipeList.Remove(recipe);
            return NoContent();

        }

        [HttpPut("ID")]
        public IActionResult UpdateRecipe(int ID, [FromBody]Recipe recipe)
        {
            var rec = RecipeStore.recipeList.First(u => u.Id == ID);
            rec.Name = recipe.Name;
            rec.Cuisine = recipe.Cuisine;
            return NoContent();

        }

    }
}
