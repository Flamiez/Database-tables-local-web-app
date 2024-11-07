using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuombaziuLenteles.Models
{
    public class tiekejas
    {

        public int id { get; set; }
        [Required]
        public string pavadinimas { get; set; }
    }
}