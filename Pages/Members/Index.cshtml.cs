using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_hotel2.Data;
using proiect_hotel2.Models;

namespace proiect_hotel2.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly proiect_hotel2.Data.proiect_hotel2Context _context;

        public IndexModel(proiect_hotel2.Data.proiect_hotel2Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }
    }
}
