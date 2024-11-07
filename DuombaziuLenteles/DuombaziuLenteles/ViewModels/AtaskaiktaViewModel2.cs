using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DuombaziuLenteles.ViewModels
{
    public class AtaskaiktaViewModel2
    {

        public List<AtaskaiktaViewModel> list { get; set; }

        [DisplayName("Nuo")]
        [Required]
        public int nuo { get; set; }
        [DisplayName("Iki")]
        [Required]
        public int iki { get; set; }
        public int viso { get; set; }
        public int visoviso { get; set; }
    }
}