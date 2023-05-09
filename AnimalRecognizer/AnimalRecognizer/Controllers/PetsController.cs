using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalRecognizer.Data;
using AnimalRecognizer.Model;

namespace AnimalRecognizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly AnimalRecognizerDBContext _context;

        public PetsController(AnimalRecognizerDBContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }
            return await _context.Pets.ToListAsync();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpGet("{type}/{colour}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetByTypeAndColour(string type, string colour)
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }

            if (type == "Cat")
            {
                var pets = _context.Pets.AsQueryable();

                pets = pets.Where(p => p.Type == Pet.PetType.Cat && p.Colour == colour);

                return await pets.ToListAsync();

            }
            else if (type == "Dog")
            {
                var pets = _context.Pets.AsQueryable();

                pets = pets.Where(p => p.Type == Pet.PetType.Dog && p.Colour == colour);

                return await pets.ToListAsync();
            }

            return NotFound();

        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            if (_context.Pets == null)
            {
                return Problem("Entity set 'AnimalRecognizerDBContext.Pets'  is null.");
            }
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(int id)
        {
            return (_context.Pets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
