using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Brygady2.Models;


namespace Brygady2.Models
{
    public class Works
    {
        public enum TYPEWork
        {
            Serwis, Dostawa, Montaż,
        }

        [Key]
        public int              IdWork              { get; set; }
        public string           Note                { get; set; } //opis instalacji sformatowany w html ? xml?
        [Display(Name = "Rodzaj Pracy")]
        public TYPEWork?        TypeWork            { get; set; } //Wybieramy rodzaj pracy Instalacja / Serwis / Dostawa
        [Display(Name = "Ustawienia Regulatora")]
        public int?              IdSettingBackup     { get; set; }
        [Display(Name = "Ustawienia Regulatora")]
        public SettingBackups   SettingBackup       { get; set; }
 
    }

 

}
