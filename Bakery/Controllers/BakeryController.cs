using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bakery.Models;


//FIXME: Det her er bare en augogenerated bandit fra en scaffold, så det er ikke sikkert det er korrekt
//Altså det er det sikkert ikke


namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryController : ControllerBase
    {
        private readonly BakeryContext _context;

        public BakeryController(BakeryContext context)
        {
            _context = context;
        }

        // GET: api/Bakery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> Getingredients()
        {
            return await _context.ingredients.ToListAsync();
        }

        // GET: api/Bakery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(int id)
        {
            var ingredient = await _context.ingredients.FindAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        // PUT: api/Bakery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return BadRequest();
            }

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bakery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
            _context.ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredient", new { id = ingredient.IngredientId }, ingredient);
        }

        // DELETE: api/Bakery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _context.ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            _context.ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientExists(int id)
        {
            return _context.ingredients.Any(e => e.IngredientId == id);
        }
    }
}
