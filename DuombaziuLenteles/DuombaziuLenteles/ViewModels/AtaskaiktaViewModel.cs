using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DuombaziuLenteles.ViewModels
{
    public class AtaskaiktaViewModel
    {
        public string Imone { get; set; }

        [DisplayName("Medžiaga")]
        public string medziaga { get; set; }

        [DisplayName("Vidutinis židinių tūris dm3")]
        public int VZidTuris { get; set; }

        [DisplayName("Darbuotojų skaičius")]
        public int DarbuotojuUzdirbusiuTarp { get; set; }

        [DisplayName("Darbuotojų bendra uždirbta suma")]
        public int DarbuotojuUzdirbusiuTarpSuma { get; set; }

        public int viso { get; set; }
        public int visoviso { get; set; }
    }
}