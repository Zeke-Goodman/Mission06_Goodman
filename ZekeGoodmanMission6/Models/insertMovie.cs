using System.ComponentModel.DataAnnotations;

namespace ZekeGoodmanMission6.Models
{
    // Model class representing a movie to be inserted

    public class insertMovie
    {
        // Primary key for identifying the movie

        [Key]
        public required int MovieId { get; set; }
        public required string Category {  get; set; }
        public required string Subcategory { get; set; }
        public required string Title { get; set; }
        public required string Year { get; set; }
        public required string Director { get; set; }
        public required string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set;}
    }
}
