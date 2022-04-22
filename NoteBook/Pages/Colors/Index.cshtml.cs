using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Colors
{
    public class IndexModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public IndexModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        public IList<Color> Color { get;set; }

        public async Task OnGetAsync()
        {
            Color = await _context.Color.ToListAsync();
        }
    }
}
