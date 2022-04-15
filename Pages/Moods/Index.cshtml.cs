using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Moods
{
    public class IndexModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public IndexModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        public IList<Mood> Mood { get;set; }

        public async Task OnGetAsync()
        {
            Mood = await _context.Mood.ToListAsync();
        }
    }
}
