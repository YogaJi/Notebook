using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Templates
{
    public class DeleteModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public DeleteModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Template Template { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Template = await _context.Template.FirstOrDefaultAsync(m => m.TemplateId == id);

            if (Template == null)
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

            Template = await _context.Template.FindAsync(id);

            if (Template != null)
            {
                _context.Template.Remove(Template);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
