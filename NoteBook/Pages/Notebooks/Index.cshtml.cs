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
    public class IndexModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public IndexModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        public IList<Notebook> Notebook { get;set; }

        public async Task OnGetAsync()
        {
            Notebook = await _context.Notebook.ToListAsync();
        }
    }
}
