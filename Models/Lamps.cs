using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Brygady2.Models;

namespace Brygady2.Models
{
    public class Lamps
    {
        [Key]
        public  int                 IdLamp             { get; set; }
        public  int                 IdModelLamp        { get; set; }
        public  ModelLamp           ModelLamp          { get; set; }
        public List<LampToProduct>  Products            { get; set; }
    }

}
