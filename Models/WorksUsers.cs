using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Brygady2.Models;

namespace Brygady2.Models
{
   
    public class WorksUsers
    {
        public int      IdWork  {get; set;}
        public string   Id  {get;set;}
        public Users    User    {get;set;}
        public Works    Work    {get;set;}
    }
}