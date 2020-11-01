using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }
        
        [DataType(DataType.Date)]
        public string dateCreated = DateTime.Now.ToString("MM/dd/yyyy");

        [Display(Name = "Create Date")]
        public String DateCreated { get => dateCreated; set => dateCreated = value; }

    [StringLength(20, MinimumLength = 3)]
        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        [Range(1, 150)]
        public int Chapter { get; set; }

        [Range(1, 176)]
        public int Verse { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'.\s-]*$")]
        [StringLength(255)]
        [Required]
        public string Note { get; set; }

        public string GetBookOfScripture()
        {
            return $"{BookName} {Chapter}:{Verse}";
        }

        public Scripture()
        {
            DateCreated = DateTime.Now.ToShortDateString();
        }
    }
}
