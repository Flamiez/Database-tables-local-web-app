using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuombaziuLenteles.Models
{
    public class tiekia_prekes
    {
        [Required]
        public int fk_SANDELYSid_SANDELYS { get; set; }
        [Required]
        public int fk_TIEKEJASid { get; set; }
    }
}