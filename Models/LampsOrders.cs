using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Brygady2.Models
{
    public class  LampsOrders
    {
        public int      IdLamp  { get; set;}
        public Lamps    Lamp    {get; set;}
        public int      IdOrder { get; set;}
        public Orders   Order   {get; set;}
    }
}