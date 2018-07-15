using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Brygady2.Models
{
    public class UserTypes
    {
        [Key]
        [Display(Name = "Rodzaj użytkownika")]
        public int      IdUserType  { get; set; }
        public String   Name        { get; set; }
        public int      Token       { get; set; }
    }
}
