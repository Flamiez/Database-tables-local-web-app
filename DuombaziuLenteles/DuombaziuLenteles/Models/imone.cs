using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace DuombaziuLenteles.Models
{
    public class imone
    {
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        [MaxLength(20)]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Biudžetas")]
        [Required]
        public float biudzetas { get; set; }
        [DisplayName("Max galimų darbuotoju")]
        [Required]
        public int max_galimas_darbuotoju_kiekis { get; set; }
    }
}