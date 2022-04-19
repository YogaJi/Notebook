using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Mood
    {
        [Key]
        public int MoodId { get; set; }
        
        public string MoodPic { get; set; }

        public ICollection<Journal> Journals { get; set; }
    }
}
