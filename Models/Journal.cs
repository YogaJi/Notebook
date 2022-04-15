using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Journal
    {
        [Key]
        public int JournalId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string BackgroundColor { get; set; }
        public string Content { get; set; }

        public int NotebookId { get; set; }
        [ForeignKey("Notebook")]
        public Notebook notebook { get; set; }


        [ForeignKey("PrimaryWeather")]
        public string weather { get; set; }
        public Weather PrimaryWeather { get; set; }


        [ForeignKey("PrimaryMood")]
        public string mood { get; set; }
        public Mood PrimaryMood { get; set; }

        /*        public int WeatherId { get; set; }
        [ForeignKey("Weather")]
        public Weather weather { get; set; }
              public int MoodId { get; set; }
               [ForeignKey("Mood")]
               public Mood mood { get; set; }*/



    }
}
