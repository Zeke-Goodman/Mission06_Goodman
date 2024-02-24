using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZekeGoodmanMission6.Models
{
    // Model class representing a movie to be inserted

    public class Movie
    {
        // Primary key for identifying the movie

        [Key]
        public required int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public required string Title { get; set; }

        [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888")]
        public required int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public required bool Edited { get; set; }
        public string? LentTo { get; set; }
        public required bool CopiedToPlex { get; set; }
        public string? Notes { get; set;}
    }
}
