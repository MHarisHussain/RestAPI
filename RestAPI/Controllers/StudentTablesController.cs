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
    public class StudentTablesController : ControllerBase
    {
        private readonly Commute_DbContext _context;

        public StudentTablesController(Commute_DbContext context)
        {
            _context = context;
        }

        // GET: api/StudentTables
        [HttpGet]
        public IEnumerable<StudentTable> GetStudentTable()
        {
            return _context.StudentTable;
        }

        // GET: api/StudentTables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentTable = await _context.StudentTable.FindAsync(id);

            if (studentTable == null)
            {
                return NotFound();
            }

            return Ok(studentTable);
        }

        // PUT: api/StudentTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentTable([FromRoute] int id, [FromBody] StudentTable studentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentTableExists(id))
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

        // POST: api/StudentTables
        [HttpPost]
        public async Task<IActionResult> PostStudentTable([FromBody] StudentTable studentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentTable.Add(studentTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentTable", new { id = studentTable.Id }, studentTable);
        }

        // DELETE: api/StudentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentTable = await _context.StudentTable.FindAsync(id);
            if (studentTable == null)
            {
                return NotFound();
            }

            _context.StudentTable.Remove(studentTable);
            await _context.SaveChangesAsync();

            return Ok(studentTable);
        }

        private bool StudentTableExists(int id)
        {
            return _context.StudentTable.Any(e => e.Id == id);
        }
    }
}