using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brygady2.Models
{
    public class MyIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
