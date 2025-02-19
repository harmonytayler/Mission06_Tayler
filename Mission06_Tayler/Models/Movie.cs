using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Tayler.Models
{
    [Table("Movies")] 
    public class Movie
    {
        [Key]
        [Column("MovieId")]
        public int MovieId { get; set; }

        // Gets the CategoryId as a foreign key and sets it to 1 as a default.
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } = 1;
        public Categories? Category { get; set; } 
        
        [Column("Title")]
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Column("Year")]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        [Column("Director")]
        public string? Director { get; set; }

        [Column("Rating")]
        public string? Rating { get; set; } 

        [Column("Edited")]
        [Required(ErrorMessage = "Please enter whether the movie is edited.")]
        public bool Edited { get; set; }

        [Column("LentTo")]
        public string? LentTo { get; set; } 

        [Column("CopiedToPlex")]
        [Required(ErrorMessage = "Please enter whether the movie is copied to Plex.")]
        public bool CopiedToPlex { get; set; } 

        [Column("Notes")]
        public string? Notes { get; set; } 
    }
}
