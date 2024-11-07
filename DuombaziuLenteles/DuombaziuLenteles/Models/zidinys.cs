using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuombaziuLenteles.Models
{
    public class zidinys
    {
        public int id { get; set; }
        [Required]
        public string vardas { get; set; }
        [Required]
        public int ilgis { get; set; }
        [Required]
        public int plotis { get; set; }
        [Required]
        public int aukstis { get; set; }
        public int fk_ADRESASid_ADRESAS { get; set; }
        public string medziaga { get; set; }





    }
}