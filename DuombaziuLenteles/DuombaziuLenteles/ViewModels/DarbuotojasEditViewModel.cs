using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DuombaziuLenteles.ViewModels
{
    public class DarbuotojasEditViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Vardas")]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Asmens kodas")]
        [Required]
        public int asmens_kodas { get; set; }
        [DisplayName("Tel. Numeris")]
        [Required]
        public string telefono_numeris { get; set; }
        [Required]
        [DisplayName("Alga")]
        public float alga { get; set; }
        [DisplayName("Įmonės ID")]
        [Required]
        public int fk_IMONEid { get; set; }
        [DisplayName("Židinio ID")]
        [Required]
        public int fk_ZIDINYSid { get; set; }

        public IList<SelectListItem> ZidiniaiList { get; set; }
    }
}