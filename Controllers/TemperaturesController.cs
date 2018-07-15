using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brygady2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Brygady2.Controllers
{
    [Produces("application/json")]
    [Route("api/temperature.json")]
    [ApiController]
    [AllowAnonymous]
    public class TemperaturesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TemperaturesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Temperatures
        [HttpGet]
        public IEnumerable<Temperatures> GetTemperatures()
        {
            return _context.Temperatures;
        }

        // GET: api/Temperatures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemperatures([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temperatures = await _context.Temperatures.FindAsync(id);

            if (temperatures == null)
            {
                return NotFound();
            }

            return Ok(temperatures);
        }

        // PUT: api/Temperatures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemperatures([FromRoute] int id, [FromBody] Temperatures temperatures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != temperatures.IdTemperature)
            {
                return BadRequest();
            }

            _context.Entry(temperatures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperaturesExists(id))
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

        // POST: api/Temperatures
        [HttpPost]
        public async Task<IActionResult> PostTemperatures([FromBody] Temperatures temperatures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Temperatures.Add(temperatures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperatures", new { id = temperatures.IdTemperature }, temperatures);
        }

        // DELETE: api/Temperatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperatures([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temperatures = await _context.Temperatures.FindAsync(id);
            if (temperatures == null)
            {
                return NotFound();
            }

            _context.Temperatures.Remove(temperatures);
            await _context.SaveChangesAsync();

            return Ok(temperatures);
        }

        private bool TemperaturesExists(int id)
        {
            return _context.Temperatures.Any(e => e.IdTemperature == id);
        }
    }
}