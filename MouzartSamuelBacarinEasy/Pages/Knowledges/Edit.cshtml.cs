using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MouzartSamuelBacarinEasy.Data;
using MouzartSamuelBacarinEasy.Models;

namespace MouzartSamuelBacarinEasy.Pages.Knowledges
{
    public class EditModel : PageModel
    {
        private readonly MouzartSamuelBacarinEasy.Data.EasyContext _context;

        public EditModel(MouzartSamuelBacarinEasy.Data.EasyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Knowledge Knowledge { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Knowledge = await _context.Knowledges.FirstOrDefaultAsync(m => m.Id == id);

            if (Knowledge == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Knowledge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowledgeExists(Knowledge.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KnowledgeExists(int id)
        {
            return _context.Knowledges.Any(e => e.Id == id);
        }
    }
}
