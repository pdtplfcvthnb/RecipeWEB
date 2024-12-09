using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWEB.Models;

namespace RecipeWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeCommentController : ControllerBase
    {
        public RecipeContext Context { get; }
        public RecipeCommentController(RecipeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<RecipeComment> recipeComments = Context.RecipeComments.ToList();
            //В <> пишем имя таблицы, а после context название таблицы+s
            return Ok(recipeComments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            RecipeComment? recipeComment = Context.RecipeComments.Where(x => x.CommentId == id).FirstOrDefault();
            if (recipeComment == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(RecipeComment recipeComment)
        {
            Context.RecipeComments.Add(recipeComment);
            Context.SaveChanges();
            return Ok(recipeComment);
        }

        [HttpPut]
        public IActionResult Update(RecipeComment recipeComment)
        {
            Context.RecipeComments.Add(recipeComment);
            Context.SaveChanges();
            return Ok(recipeComment);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            RecipeComment? recipeComment = Context.RecipeComments.Where(x => x.CommentId == id).FirstOrDefault();
            if (recipeComment == null)
            {
                return BadRequest("Not Found");
            }
            Context.RecipeComments.Remove(recipeComment);
            Context.SaveChanges();
            return Ok();
        }
    }
}
