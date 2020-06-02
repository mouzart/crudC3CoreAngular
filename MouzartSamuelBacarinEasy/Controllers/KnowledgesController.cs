using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MouzartSamuelBacarinEasy.Data;
using MouzartSamuelBacarinEasy.Models;

namespace MouzartSamuelBacarinEasy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgesController : ControllerBase
    {
        private readonly EasyContext _context;

        public KnowledgesController(EasyContext context)
        {
            _context = context;
        }

        // GET: api/Knowledges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Knowledge>>> GetKnowledges()
        {
            return await _context.Knowledges.ToListAsync();
        }

        // GET: api/Knowledges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Knowledge>> GetKnowledge(int id)
        {
            var knowledge = await _context.Knowledges.FindAsync(id);

            if (knowledge == null)
            {
                return NotFound();
            }

            return knowledge;
        }

        // PUT: api/Knowledges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnowledge(int id, Knowledge knowledge)
        {
            if (id != knowledge.Id)
            {
                return BadRequest();
            }

            _context.Entry(knowledge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowledgeExists(id))
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

        // POST: api/Knowledges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Knowledge>> PostKnowledge(Knowledge knowledge)
        {
            _context.Knowledges.Add(knowledge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnowledge", new { id = knowledge.Id }, knowledge);
        }

        // DELETE: api/Knowledges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Knowledge>> DeleteKnowledge(int id)
        {
            var knowledge = await _context.Knowledges.FindAsync(id);
            if (knowledge == null)
            {
                return NotFound();
            }

            _context.Knowledges.Remove(knowledge);
            await _context.SaveChangesAsync();

            return knowledge;
        }

        private bool KnowledgeExists(int id)
        {
            return _context.Knowledges.Any(e => e.Id == id);
        }
    }
}
