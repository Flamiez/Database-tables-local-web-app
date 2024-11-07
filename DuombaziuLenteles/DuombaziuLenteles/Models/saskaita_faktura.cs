using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuombaziuLenteles.Models
{
    public class saskaita_faktura
    {
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime pasirasymo_data { get; set; }
        [Required]
        public float kaina { get; set; }
        [Required]
        public int fk_IMONEid { get; set; }
        [Required]
        public int fk_PIRKEJASid_PIRKEJAS { get; set; }
    }
}