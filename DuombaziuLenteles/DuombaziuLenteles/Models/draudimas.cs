using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuombaziuLenteles.Models
{
    public class draudimas
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Galioja nuo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime pasirasymo_data { get; set; }

        [DisplayName("Galioja iki")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime galiojimo_laikotarpis { get; set; }

        public int fk_ZIDINYSid { get; set; }
        public virtual zidinys zidinys { get; set; }
    }
}