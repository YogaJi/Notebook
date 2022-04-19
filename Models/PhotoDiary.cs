using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class PhotoDiary
    {
        [Key]
        public int PhotoDiaryId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string FirstContent { get; set; }
        public string secondContent { get; set; }
        
        public int TemplateId { get; set; }
        public Template template { get; set; }
    }
}
