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
    public class IndexModel : PageModel
    {
        private readonly MouzartSamuelBacarinEasy.Data.EasyContext _context;

        public IndexModel(MouzartSamuelBacarinEasy.Data.EasyContext context)
        {
            _context = context;
        }

        public IList<Knowledge> Knowledge { get;set; }

        public async Task OnGetAsync()
        {
            Knowledge = await _context.Knowledges.ToListAsync();
        }
    }
}
