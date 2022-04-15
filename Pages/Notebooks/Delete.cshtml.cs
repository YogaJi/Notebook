using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Notebooks
{
    public class DeleteModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public DeleteModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notebook Notebook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notebook = await _context.Notebook.FirstOrDefaultAsync(m => m.NotebookId == id);

            if (Notebook == null)
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

            Notebook = await _context.Notebook.FindAsync(id);

            if (Notebook != null)
            {
                _context.Notebook.Remove(Notebook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
