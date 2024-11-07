using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DuombaziuLenteles.ViewModels
{
    public class DraudimasViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Židinys")]
        public string zidinys { get; set; }

        [DisplayName("Galioja nuo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime pasirasymo_data { get; set; }

        [DisplayName("Galioja iki")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime galiojimo_laikotarpis { get; set; }

    }
}