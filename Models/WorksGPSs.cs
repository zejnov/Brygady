using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Brygady2.Models;

namespace Brygady2.Models
{
     public class WorksGPSs
    {
        public int IdWork {get; set;}
        public int IdGPS {get;set;}
        public GPSs GPS {get;set;}
        public Works Work {get;set;}

    }
}