using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MouzartSamuelBacarinEasy.Data;
using MouzartSamuelBacarinEasy.Models;

namespace MouzartSamuelBacarinEasy.Pages.Knowledges
{
    public class CreateModel : PageModel
    {
        private readonly MouzartSamuelBacarinEasy.Data.EasyContext _context;

        public CreateModel(MouzartSamuelBacarinEasy.Data.EasyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Knowledge Knowledge { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Knowledges.Add(Knowledge);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
