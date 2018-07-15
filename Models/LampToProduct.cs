using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Brygady2.Models
{
    public class LampToProduct
    {   
        public int      IdProduct       { get; set; }
        public Product  products        { get; set; }

        public int      IdLamp          { get; set; }
        public Lamps    lamps            { get; set; }
    }
}
