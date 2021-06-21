using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverTablesController : ControllerBase
    {
        private readonly Commute_DbContext _context;

        public DriverTablesController(Commute_DbContext context)
        {
            _context = context;
        }

        // GET: api/DriverTables
        [HttpGet]
        public IEnumerable<DriverTable> GetDriverTable()
        {
            return _context.DriverTable;
        }

        // GET: api/DriverTables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driverTable = await _context.DriverTable.FindAsync(id);

            if (driverTable == null)
            {
                return NotFound();
            }

            return Ok(driverTable);
        }

        // PUT: api/DriverTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverTable([FromRoute] int id, [FromBody] DriverTable driverTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driverTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(driverTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverTableExists(id))
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

        // POST: api/DriverTables
        [HttpPost]
        public async Task<IActionResult> PostDriverTable([FromBody] DriverTable driverTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DriverTable.Add(driverTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverTable", new { id = driverTable.Id }, driverTable);
        }

        // DELETE: api/DriverTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driverTable = await _context.DriverTable.FindAsync(id);
            if (driverTable == null)
            {
                return NotFound();
            }

            _context.DriverTable.Remove(driverTable);
            await _context.SaveChangesAsync();

            return Ok(driverTable);
        }

        private bool DriverTableExists(int id)
        {
            return _context.DriverTable.Any(e => e.Id == id);
        }
    }
}