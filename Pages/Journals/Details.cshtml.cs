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
    public class DetailsModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public DetailsModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        public Journal Journal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journal = await _context.Journal
                .Include(j => j.PrimaryMood)
                .Include(j => j.PrimaryWeather).FirstOrDefaultAsync(m => m.JournalId == id);

            if (Journal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
