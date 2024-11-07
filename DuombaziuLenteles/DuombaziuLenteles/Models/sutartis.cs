using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuombaziuLenteles.Models
{
    public class sutartis
    {
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime pasirasymo_data { get; set; }
        [Required]
        public float kaina { get; set; }
        [Required]
        public int fk_TIEKEJASid { get; set; }
        [Required]
        public int fk_IMONEid { get; set; }
    }
}