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
    public class DetailsModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public DetailsModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        public Color Color { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = await _context.Color.FirstOrDefaultAsync(m => m.ColorId == id);

            if (Color == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
