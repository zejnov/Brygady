using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Brygady2.Models
{
    public class ModelLamp
    {
        [Key]
        public int IdModelLamp { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
