using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace DuombaziuLenteles.Models
{
    public class adresas
    {
        [DisplayName("Miestas")]
        [Required]
        public string miestas { get; set; }
        [DisplayName("Pašto kodas")]
        [Required]
        public int pasto_kodas { get; set; }
        public int id_ADRESAS { get; set; }
        public int fk_PIRKEJASid_PIRKEJAS { get; set; }

    }
}