using System.ComponentModel.DataAnnotations;

namespace Brygady2.Models
{
    public class Categories
    {
        [Key]
        public int          IdCategory      { get; set; }
        [Required]
        public string       Name            { get; set; }
        public string       Comment         { get; set; }
    }
}
