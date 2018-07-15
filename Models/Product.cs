using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Brygady2.Models
{
    public class Product
    {
        [Key]
        public int      IdProduct       { get; set; }
        [Display(Name = "Model")]
        public string   Name            { get; set; }
        [Display(Name = "Producent")]
        public string   Manufacturer    { get; set; }
        [Display(Name = "Na stanie")]
        public int      InStock         { get; set; }
        [Display(Name = "Opis")]
        public string   Description     { get; set; } // sformatowany w formacie json lub xml?
        public int IdCategory { get; set; }
        [Display(Name = "Kategoria")]
        public Categories Category        { get; set; } // Przypisujemy połączenie jeden do wielu?

       public  List<LampToProduct> lamps       { get; set; }
    }
}
