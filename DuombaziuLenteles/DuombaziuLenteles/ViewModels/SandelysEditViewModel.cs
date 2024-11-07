﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DuombaziuLenteles.ViewModels
{
    public class SandelysEditViewModel
    {
        [DisplayName("Skirtingų saugomų medžiagų kiekis")]
        [Required]
        public int skirtingu_saugomu_medziagu_kiekis { get; set; }
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Adresas")]
        [Required]
        public string adresas { get; set; }
        [DisplayName("Talpa tonomis")]
        [Required]
        public int talpa { get; set; }
        [DisplayName("Pastatymo metai")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime pastatymo_metai { get; set; }
        [DisplayName("Sandelio ID")]
        [Required]
        public int id_SANDELYS { get; set; }
        [DisplayName("Įmonė")]
        [Required]
        public int fk_IMONEid { get; set; }

        public IList<SelectListItem> ImonesList { get; set; }

    }
}