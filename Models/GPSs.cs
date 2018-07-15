using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Brygady2.Models
{
    public class GPSs
    {   
        [Key]
        public int                  IdGPS   { get; set; }
        [Required]
        public string               Lat     { get; set; }
        [Required]
        public string               LON     { get; set; }
        public float?      Ele     { get; set; }
        [Required]
        // [DataType(DataType.Date)]
        //   [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}}",ApplyFormatInEditMode =true)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime   Time    { get; set; }

        [StringLength(100, ErrorMessage = " name cannot be longer than 100 characters.")]
        public string               Name { get; set; }
        public string               Comment { get; set; }
    }
}
