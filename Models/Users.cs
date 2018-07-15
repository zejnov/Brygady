using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Brygady2.Models
{
    public class Users : IdentityUser
    {
  
        public Nullable<int> IdUserType             { get; set; } // zdjąć nulla
        [MaxLength(50)]
        [Display(Name = "Imie")]
        public string       FirstName               { get; set; }
        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public string       LastName                { get; set; }

        public UserTypes    UserType                { get; set; }

    }
}
