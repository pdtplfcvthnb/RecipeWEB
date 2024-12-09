using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWEB.Models;

namespace RecipeWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRecipeController : ControllerBase
    {
        public RecipeContext Context { get; }
        public FavoriteRecipeController(RecipeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<FavoriteRecipe> favoriteRecipes = Context.FavoriteRecipes.ToList();
            //В <> пишем имя таблицы, а после context название таблицы+s
            return Ok(favoriteRecipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FavoriteRecipe? favoriteRecipe = Context.FavoriteRecipes.Where(x => x.FavoriteRecipeId == id).FirstOrDefault();
            if (favoriteRecipe == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(FavoriteRecipe favoriteRecipe)
        {
            Context.FavoriteRecipes.Add(favoriteRecipe);
            Context.SaveChanges();
            return Ok(favoriteRecipe);
        }

        [HttpPut]
        public IActionResult Update(FavoriteRecipe favoriteRecipe)
        {
            Context.FavoriteRecipes.Add(favoriteRecipe);
            Context.SaveChanges();
            return Ok(favoriteRecipe);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            FavoriteRecipe? favoriteRecipe = Context.FavoriteRecipes.Where(x => x.FavoriteRecipeId == id).FirstOrDefault();
            if (favoriteRecipe == null)
            {
                return BadRequest("Not Found");
            }
            Context.FavoriteRecipes.Remove(favoriteRecipe);
            Context.SaveChanges();
            return Ok();
        }
    }
}
