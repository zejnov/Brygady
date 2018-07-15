using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Brygady2.Models;

namespace Brygady2.Models
{
   
    public class WorksPhotos
    {
        public int      IdWork      {get;set;}
        public int      IdPhoto     {get;set;}
        public Photos   Photo       {get;set;}
        public Works    Work        {get;set;}
    }
}