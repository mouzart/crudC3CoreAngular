using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MouzartSamuelBacarinEasy.Data;
using MouzartSamuelBacarinEasy.Models;

namespace MouzartSamuelBacarinEasy.Pages.Knowledges
{
    public class DeleteModel : PageModel
    {
        private readonly MouzartSamuelBacarinEasy.Data.EasyContext _context;

        public DeleteModel(MouzartSamuelBacarinEasy.Data.EasyContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Knowledge = await _context.Knowledges.FindAsync(id);

            if (Knowledge != null)
            {
                _context.Knowledges.Remove(Knowledge);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
