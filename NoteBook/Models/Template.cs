using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Template
    {
        [Key]
        public int TemplateId { get; set; }
        public string Templates { get; set; }
        public ICollection<PhotoDiary> PhotoDiarys { get; set; }
    }
}
