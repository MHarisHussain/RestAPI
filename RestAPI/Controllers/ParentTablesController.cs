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
    public class ParentTablesController : ControllerBase
    {
        private readonly Commute_DbContext _context;

        public ParentTablesController(Commute_DbContext context)
        {
            _context = context;
        }

        // GET: api/ParentTables
        [HttpGet]
        public IEnumerable<ParentTable> GetParentTable()
        {
            return _context.ParentTable;
        }

        // GET: api/ParentTables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parentTable = await _context.ParentTable.FindAsync(id);

            if (parentTable == null)
            {
                return NotFound();
            }

            return Ok(parentTable);
        }

        // PUT: api/ParentTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParentTable([FromRoute] int id, [FromBody] ParentTable parentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parentTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(parentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentTableExists(id))
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

        // POST: api/ParentTables
        [HttpPost]
        public async Task<IActionResult> PostParentTable([FromBody] ParentTable parentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParentTable.Add(parentTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParentTable", new { id = parentTable.Id }, parentTable);
        }

        // DELETE: api/ParentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParentTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parentTable = await _context.ParentTable.FindAsync(id);
            if (parentTable == null)
            {
                return NotFound();
            }

            _context.ParentTable.Remove(parentTable);
            await _context.SaveChangesAsync();

            return Ok(parentTable);
        }

        private bool ParentTableExists(int id)
        {
            return _context.ParentTable.Any(e => e.Id == id);
        }
    }
}