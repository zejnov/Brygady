using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Brygady2.Models
{
    public class Orders
    {
        [Key]
        public int      IdOrder                  { get; set; }
        public Nullable<int> IdWork              { get; set; }
        [Display(Name = "Ilość")]
        public int      Quantity                 { get; set; }
        [Display(Name = "Źródło")]
        public string   SourceOrder             { get; set; }
        [Display(Name = "Produkcja")]
        public string   ProductionStatus        { get; set; }   // zmienić na enum
        [Display(Name = "Realizacja")]
        public string   RealizationStatus       { get; set; }   // zmienić na enum
        [Display(Name = "Płatność")]                            // zmienić ewentualnie na rodzaj umowy?
        public string   PaymentMethod           { get; set; }
        [Display(Name = "Adres Dostawy")]                       // zmienić na enum
        public string   DeliveryTown            { get; set; }
        [Display(Name = "Uwagi")]
        public string   Comment                 { get; set; }
        [Display(Name = "Rodzaj")]
        public Works    Work                    { get; set; }
    }
}
