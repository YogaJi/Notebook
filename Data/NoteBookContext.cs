using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteBook.Models;

namespace NoteBook.Data
{
    public class NoteBookContext : DbContext
    {
        public NoteBookContext (DbContextOptions<NoteBookContext> options)
            : base(options)
        {
        }

        public DbSet<NoteBook.Models.Journal> Journal { get; set; }

        public DbSet<NoteBook.Models.Mood> Mood { get; set; }

        public DbSet<NoteBook.Models.Notebook> Notebook { get; set; }

        public DbSet<NoteBook.Models.Weather> Weather { get; set; }

        public DbSet<NoteBook.Models.Color> Color { get; set; }

        public DbSet<NoteBook.Models.PhotoDiary> PhotoDiary { get; set; }

        public DbSet<NoteBook.Models.Template> Template { get; set; }
    }
}
