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
    public class CandidatesController : ControllerBase
    {
        private readonly EasyContext _context;

        public CandidatesController(EasyContext context)
        {
            _context = context;
        }

        // GET: api/Candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            var candidate = await _context.Candidates.FirstAsync(c => c.Id == id);
            candidate.WorkLoad = _context.WorkLoads.First(wl => wl.CandidateId == candidate.Id);
            candidate.WorkSchedule = _context.WorkSchedules.First(ws => ws.CandidateId == candidate.Id);
            candidate.CandidateKnowledges = _context.CandidateKnowledges.Where(ck => ck.CandidateId == candidate.Id).ToList();
            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // PUT: api/Candidate s/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            try
            {
                WorkLoad workLoad = candidate.WorkLoad;
                WorkSchedule workSchedule = candidate.WorkSchedule;
                List<CandidateKnowledge> candidateKnowledges = candidate.CandidateKnowledges;
                List<CandidateKnowledge> candidateKnowledgesForSave = new List<CandidateKnowledge>();
                candidate.WorkSchedule = null;
                candidate.WorkLoad = null;
                _context.Entry(candidate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _context.Entry(workLoad).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _context.Entry(workSchedule).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                foreach (CandidateKnowledge item in candidateKnowledges)
                {
                    _context.Entry(item).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/Candidates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            WorkLoad workLoad = candidate.WorkLoad;
            WorkSchedule workSchedule = candidate.WorkSchedule;
            List<CandidateKnowledge> candidateKnowledges = candidate.CandidateKnowledges;
            List<CandidateKnowledge> candidateKnowledgesForSave = new List<CandidateKnowledge>();
            candidate.WorkSchedule = null;
            candidate.WorkLoad = null;
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            workLoad.CandidateId = candidate.Id;
            _context.WorkLoads.Add(workLoad);
            workSchedule.CandidateId = candidate.Id;
            _context.WorkSchedules.Add(workSchedule);
            await _context.SaveChangesAsync();
            foreach (CandidateKnowledge item in candidateKnowledges)
            {
                CandidateKnowledge candidateKnowledge = new CandidateKnowledge();
                candidateKnowledge.CandidateId = candidate.Id;
                candidateKnowledge.KnowledgeId = item.KnowledgeId;
                candidateKnowledge.Rate = item.Rate;
                candidateKnowledgesForSave.Add(candidateKnowledge);
                //_context.CandidateKnowledges.Add(candidateKnowledge);
                //await _context.SaveChangesAsync();
            }
            _context.CandidateKnowledges.AddRange(candidateKnowledgesForSave);
            await _context.SaveChangesAsync();
            candidate.WorkSchedule = null;
            candidate.WorkLoad = null;
            return candidate;
        }

        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
