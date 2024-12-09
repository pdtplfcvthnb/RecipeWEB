using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWEB.Models;

namespace RecipeWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeRatingController : ControllerBase
    {
        public RecipeContext Context { get; }
        public RecipeRatingController(RecipeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<RecipeRating> recipeRatings = Context.RecipeRatings.ToList();
            //В <> пишем имя таблицы, а после context название таблицы+s
            return Ok(recipeRatings);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            RecipeRating? recipeRating = Context.RecipeRatings.Where(x => x.RatingId == id).FirstOrDefault();
            if (recipeRating == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(RecipeRating recipeRating)
        {
            Context.RecipeRatings.Add(recipeRating);
            Context.SaveChanges();
            return Ok(recipeRating);
        }

        [HttpPut]
        public IActionResult Update(RecipeRating recipeRating)
        {
            Context.RecipeRatings.Add(recipeRating);
            Context.SaveChanges();
            return Ok(recipeRating);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            RecipeRating? recipeRating = Context.RecipeRatings.Where(x => x.RatingId == id).FirstOrDefault();
            if (recipeRating == null)
            {
                return BadRequest("Not Found");
            }
            Context.RecipeRatings.Remove(recipeRating);
            Context.SaveChanges();
            return Ok();
        }
    }
}
