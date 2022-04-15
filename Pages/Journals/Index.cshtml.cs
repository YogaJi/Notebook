using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Journals
{
    public class IndexModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public IndexModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get;set; }

        public async Task OnGetAsync()
        {
            Journal = await _context.Journal
                .Include(j => j.PrimaryMood)
                .Include(j => j.PrimaryWeather).ToListAsync();
        }
    }
}
