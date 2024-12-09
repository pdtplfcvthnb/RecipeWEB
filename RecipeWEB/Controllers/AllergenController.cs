using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWEB.Models;

namespace RecipeWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergenController : ControllerBase
    {
        public RecipeContext Context { get; }
        public AllergenController(RecipeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Allergen> allergens = Context.Allergens.ToList();
            //В <> пишем имя таблицы, а после context название таблицы+s
            return Ok(allergens);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Allergen? allergen = Context.Allergens.Where(x => x.AllergenId == id).FirstOrDefault();
            if (allergen == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Allergen allergen)
        {
            Context.Allergens.Add(allergen);
            Context.SaveChanges();  
            return Ok(allergen);
        }

        [HttpPut]
        public IActionResult Update(Allergen allergen)
        {
            Context.Allergens.Add(allergen);
            Context.SaveChanges();
            return Ok(allergen);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Allergen? allergen = Context.Allergens.Where(x => x.AllergenId == id).FirstOrDefault();
            if (allergen == null)
            {
                return BadRequest("Not Found");
            }
            Context.Allergens.Remove(allergen);
            Context.SaveChanges();
            return Ok();
        }


    }
}
