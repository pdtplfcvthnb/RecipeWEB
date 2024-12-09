﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWEB.Models;

namespace RecipeWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        public RecipeContext Context { get; }
        public RecipeIngredientController(RecipeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<RecipeIngredient> recipeIngredients = Context.RecipeIngredients.ToList();
            //В <> пишем имя таблицы, а после context название таблицы+s
            return Ok(recipeIngredients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            RecipeIngredient? recipeIngredient = Context.RecipeIngredients.Where(x => x.IngredientId == id && x.RecipeId == id).FirstOrDefault();
            if (recipeIngredient == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(RecipeIngredient recipeIngredient)
        {
            Context.RecipeIngredients.Add(recipeIngredient);
            Context.SaveChanges();
            return Ok(recipeIngredient);
        }

        [HttpPut]
        public IActionResult Update(RecipeIngredient recipeIngredient)
        {
            Context.RecipeIngredients.Add(recipeIngredient);
            Context.SaveChanges();
            return Ok(recipeIngredient);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            RecipeIngredient? recipeIngredient = Context.RecipeIngredients.Where(x => x.IngredientId == id && x.RecipeId == id).FirstOrDefault();
            if (recipeIngredient == null)
            {
                return BadRequest("Not Found");
            }
            Context.RecipeIngredients.Remove(recipeIngredient);
            Context.SaveChanges();
            return Ok();
        }
    }
}