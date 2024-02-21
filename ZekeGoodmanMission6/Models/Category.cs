using System.ComponentModel.DataAnnotations;

namespace ZekeGoodmanMission6.Models
{
    public class Category
    {
        [Key]
        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}
