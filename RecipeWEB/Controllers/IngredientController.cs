using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWEB.Models;

namespace RecipeWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        public RecipeContext Context { get; }
        public IngredientController(RecipeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Ingredient> ingredients = Context.Ingredients.ToList();
            //В <> пишем имя таблицы, а после context название таблицы+s
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Ingredient? ingredient = Context.Ingredients.Where(x => x.IngredientId == id).FirstOrDefault();
            if (ingredient == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Ingredient ingredient)
        {
            Context.Ingredients.Add(ingredient);
            Context.SaveChanges();
            return Ok(ingredient);
        }

        [HttpPut]
        public IActionResult Update(Ingredient ingredient)
        {
            Context.Ingredients.Add(ingredient);
            Context.SaveChanges();
            return Ok(ingredient);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Ingredient? ingredient = Context.Ingredients.Where(x => x.IngredientId == id).FirstOrDefault();
            if (ingredient == null)
            {
                return BadRequest("Not Found");
            }
            Context.Ingredients.Remove(ingredient);
            Context.SaveChanges();
            return Ok();
        }
    }
}
