using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Brygady2.Models
{
    public class Photos
    {
        [Key]
        public int      IdPhoto                 { get; set; }

        [Required]
        [Display(Name = "Nazwa zdjêcia")]
        public string   PhotoName               { get; set; }

        [Required]
        [Display(Name = "Zdjêcie")]
        public string   PhotoURL                  { get; set; }

        public string   PhotoThumbnailURL         { get; set; }

        [Display(Name = "Komentarz")]
        public string   PhotoInfo               { get; set; } 
     }


}
