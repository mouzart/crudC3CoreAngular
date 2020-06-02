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
    public class DetailsModel : PageModel
    {
        private readonly MouzartSamuelBacarinEasy.Data.EasyContext _context;

        public DetailsModel(MouzartSamuelBacarinEasy.Data.EasyContext context)
        {
            _context = context;
        }

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
    }
}
