using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace DuombaziuLenteles.Models
{
    public class pirkejas
    {
        [DisplayName("Vardas")]
        [MaxLength(20)]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [MaxLength(20)]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Asmens kodas")]
        [Required]
        public int asm_kodas { get; set; }
        [DisplayName("Tel. Numeris")]
        [Required]
        public string tel_numeris { get; set; }
        [Required]
        public int id_PIRKEJAS { get; set; }
    }
}