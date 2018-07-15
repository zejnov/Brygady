using System.ComponentModel.DataAnnotations;

namespace Brygady2.Models
{
    public class Temperatures
    {
            [Key]      
            public int      IdTemperature { get; set; }
            public string   Temperature { get; set; }
            public string   Comment { get; set; }
        
    }
}
