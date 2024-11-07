using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DuombaziuLenteles.ViewModels
{
    public class DraudimasEditViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Židinys")]
        public int fk_ZIDINYSid { get; set; }

        [DisplayName("Galioja nuo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime pasirasymo_data { get; set; }

        [DisplayName("Galioja iki")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime galiojimo_laikotarpis { get; set; }

        public IList<SelectListItem> ZidiniaiList { get; set; }


    }
}