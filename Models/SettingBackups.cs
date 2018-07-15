using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Brygady2.Models
{
    public class SettingBackups
    {
        public enum BATTERYType
        {
            GEL, AGM, Liquid
        }

        public enum TIME
        {
           H1, H2, H3, H4, H5, H6, H7, H8,H9,H10
        }

        public enum TIMET0T
        {
            H1, H2, H3, H4, H5, H6, H7, T0T
        }
        public enum DIM
        {
            D100, D90, D80, D70, D60, D50, D40, D30, D20, D10, D00
        }
        public enum DN
        {
            DN30, DN35, DN40, DN45, DN50
        }
        public enum LVD
        {
            LVD118, LVD117, LVD116, LVD115,LVD114,LVD113,LVD112,LVD111,LVD109
        }
    

        [Key]
        [Display(Name = "Ustawienia Regulatora")]
        public int          IdSettingBackup         { get; set; }
        [Display(Name ="Czas 1")]
        public TIME?        Time1                   { get; set; }
        [Display(Name = "Redukcja 1")]
        public DIM?         Dim1                    { get; set; }
        [Display(Name = "Czas 2")]
        public TIMET0T?     Time2                   { get; set; }
        [Display(Name = "Redukcja 2")]
        public DIM?         Dim2                    { get; set; }
        [Display(Name = "Czas 3")]
        public TIME?        Time3                   { get; set; }
        [Display(Name = "Redukcja 3")]
        public DIM?         Dim3                    { get; set; }
        [Display(Name = "Typ akumulatora")]
        public BATTERYType? Batterytype             { get; set; }
        [Display(Name = "Napięcie day/night")]
        public DN           Dn                      { get; set; }
        [Display(Name = "Napięcie LVD")]
        public LVD          Lvd                     { get; set; }
        [Display(Name = "Komentarz")]
        public string       Comment                 { get; set; }

        public string FullSettingBackup
        {
            get
            {
                string full = Comment.ToString() + ": " +Time1.ToString() + "  " + Dim1.ToString() + " " + Time2.ToString() + " " + Dim2.ToString() + " " + Time3.ToString() + " " + Dim3.ToString() + " " + Batterytype.ToString() + " " + Dn.ToString() + " " + Lvd.ToString() + " " ;

                return full;
            }
           
        }

       
    }
}
